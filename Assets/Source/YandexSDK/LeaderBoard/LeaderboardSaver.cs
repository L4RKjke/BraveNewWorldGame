using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardSaver : MonoBehaviour
{
    private PlayerProgress _progress;

    private const string _leaderboardName = "BestOfTheBest";

    private void OnEnable()
    {
        if (PlayerAccount.IsAuthorized == true)
            _progress.NewLevelOpened += AddPlayerToLeaderboard;
    }

    private void OnDisable()
    {
        if (PlayerAccount.IsAuthorized == true)
            _progress.NewLevelOpened -= AddPlayerToLeaderboard;
    }

    public void AddPlayerToLeaderboard()
    {
        Leaderboard.GetPlayerEntry(_leaderboardName, (result) =>
        {
            if (result == null || result.score < _progress.OpenedLevel)
                Leaderboard.SetScore(_leaderboardName, _progress.OpenedLevel);
        });
    }
}
