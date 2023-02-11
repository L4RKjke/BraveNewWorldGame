using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPanels : MonoBehaviour
{
    [SerializeField] private PanelWin _panelWin;
    [SerializeField] private PanelLose _panelLose;
    [SerializeField] private PlayerWallet _playerWallet;

    private int _totalEXP = 0;
    private int _totalGold = 0;

    private void Awake()
    {
        _panelWin.Init(_playerWallet);
        _panelLose.Init(_playerWallet);
    }

    public void End(bool isWin)
    {
        if(isWin)
        {
            _panelWin.gameObject.SetActive(true);
            _panelWin.SetExpirience(_totalEXP);
            _panelWin.SetGoldAndCrystals(_totalGold);
        }
        else
        {
            _panelLose.gameObject.SetActive(true);
            _panelLose.SetRewards(_totalGold, _totalEXP);
        }
    }

    public void AddRewards(int gold, int exp)
    {
        _totalEXP += exp;
        _totalGold += gold;
    }

    private void ResetRewards()
    {
        _totalEXP = 0;
        _totalGold = 0;
    }
}
