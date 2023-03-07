using UnityEngine;
using TMPro;

public class LeaderboardElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerNick;
    [SerializeField] private TMP_Text _playerPlace;
    [SerializeField] private TMP_Text _playerResult;

    public void Initialize(string nick, int playerResult, bool isPlayer, int place)
    {
        _playerNick.text = nick;
        _playerResult.text = playerResult.ToString();
        _playerPlace.text = place.ToString();
    }
}