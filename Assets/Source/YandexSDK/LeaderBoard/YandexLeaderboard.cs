using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LeaderboardView))]
public class YandexLeaderboard : MonoBehaviour
{
    private LeaderboardView _leaderboardView;

    private const string _leaderboardName = "BestOfTheBest";
    private int _maxPlace = 50;

    private void Awake()
    {
        _leaderboardView = GetComponent<LeaderboardView>();
    }

    private void Start()
    {
        FormListOfTopPlayers();
    }

    public void FormListOfTopPlayers()
    {
        List<PlayerInfoLeaderboard> top50Players = new List<PlayerInfoLeaderboard>();

#if !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
        };
#endif

        Leaderboard.GetEntries(_leaderboardName, (result) =>
        {
            int resultsAmount = result.entries.Length;

            resultsAmount = Mathf.Clamp(resultsAmount, 0, _maxPlace);

            for (int i = 0; i < resultsAmount; i++)
            {
                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = "Anonymos";

                int score = result.entries[i].score;

                top50Players.Add(new PlayerInfoLeaderboard(name, score));
            }

            if (resultsAmount < _maxPlace)
            {
                int leftPlace = _maxPlace - resultsAmount;

                for (int i = 0; i < leftPlace; i++)
                {
                    top50Players.Add(new PlayerInfoLeaderboard("Anonymos", leftPlace - i - 666));
                }
            }

            Debug.Log(top50Players.Count);
            _leaderboardView.ConstructLeaderboard(top50Players, _maxPlace);
        });
    }
}

public class PlayerInfoLeaderboard
{
    public string Name { get; private set; }
    public int Level { get; private set; }

    public PlayerInfoLeaderboard(string name, int level)
    {
        Name = name;
        Level = level;
    }
}
