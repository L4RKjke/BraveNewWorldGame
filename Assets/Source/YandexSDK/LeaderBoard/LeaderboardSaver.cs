using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardSaver : MonoBehaviour
{
    [SerializeField] private PlayerProgress _progress;

    private const string _leaderboardName = "BestOfTheBest";

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        if (PlayerAccount.IsAuthorized == true)
            _progress.NewLevelOpened += AddPlayerToLeaderboard;

        yield break;
    }

    public void AddPlayerToLeaderboard()
    {
        Leaderboard.GetPlayerEntry(_leaderboardName, (result) =>
        {
            if (result == null || result.score < _progress.OpenedLevel)
            {
                Debug.Log("Записываю");
                Leaderboard.SetScore(_leaderboardName, _progress.OpenedLevel);
            }

            Debug.Log("Открыт " + _progress.OpenedLevel);
        });
    }
}
