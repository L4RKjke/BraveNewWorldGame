using System.Collections.Generic;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform _parentObject;
    [SerializeField] private GameObject _leaderboardElementPrefab;

    private List<GameObject> _spawnedElements = new List<GameObject>();

    public void ConstructLeaderboard(List<PlayerInfoLeaderboard> playersInfo, int maxPlace)
    {
        ClearLeaderboard();

        int currentPlace = 1;

        foreach (PlayerInfoLeaderboard info in playersInfo)
        {
            GameObject leaderboardElementInstance = Instantiate(_leaderboardElementPrefab, _parentObject);

            LeaderboardElement leaderboardElement = leaderboardElementInstance.GetComponent<LeaderboardElement>();
            leaderboardElement.Initialize(info.Name, info.Level, false, currentPlace);

            _spawnedElements.Add(leaderboardElementInstance);
            currentPlace++;
        }
    }

    private void ClearLeaderboard()
    {
        foreach (var element in _spawnedElements)
            Destroy(element);

        _spawnedElements = new List<GameObject>();
    }
}