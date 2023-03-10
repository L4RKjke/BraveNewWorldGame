using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinalPanels : MonoBehaviour
{
    [SerializeField] private PanelWin _panelWin;
    [SerializeField] private PanelLose _panelLose;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private CharactersStorage _charactersStorage;
    [SerializeField] private PanelHunt _panelHunt;
    [SerializeField] private PlayerProgress _progress;

    private List<int> _charactersID = new List<int>();
    private int _totalEXP = 0;
    private int _totalGold = 0;

    public UnityAction BattleEnd;

    private void Awake()
    {
        _panelWin.Init(_playerWallet);
        _panelLose.Init(_playerWallet);
    }

    public void AddCharacterId(int id)
    {
        _charactersID.Add(id);
    }

    public void End(bool isWin)
    {
        if (isWin)
        {
            _panelWin.gameObject.SetActive(true);
            _panelWin.SetRewards(_totalGold, _totalEXP, _panelHunt.GetCurrentLevel(), _progress.OpenedLevel);
            _progress.LevelComplete(_panelHunt.GetCurrentLevel());
        }
        else
        {
            int losePercent = 3;
            _totalEXP /= losePercent;
            _panelLose.gameObject.SetActive(true);
            _panelLose.SetRewards(_totalGold / losePercent, _totalEXP, _panelHunt.GetCurrentLevel(), _progress.OpenedLevel);
        }

        for(int i = 0; i < _charactersID.Count; i++)
        {
            GameObject character = _charactersStorage.GetCharacter(_charactersID[i]);
            character.GetComponent<CharacterStats>().GetExpirience(_totalEXP / _charactersID.Count, _panelHunt.GetCurrentLevel());
        }

        BattleEnd?.Invoke();
    }

    public void AddRewards(int gold, int exp)
    {
        _totalEXP += exp;
        _totalGold += gold;
    }

    public void ResetRewards()
    {
        _totalEXP = 0;
        _totalGold = 0;
    }
}
