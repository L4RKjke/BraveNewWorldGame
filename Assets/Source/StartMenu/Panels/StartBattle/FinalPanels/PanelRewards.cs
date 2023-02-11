using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelRewards : MonoBehaviour
{
    protected PlayerWallet _playerWallet;

    public void Init(PlayerWallet wallet)
    {
        _playerWallet = wallet;
    }

    protected void AddRewards(int gold, int crystals = 0)
    {
        _playerWallet.ChangeGold(gold);
        _playerWallet.ChangeCrystals(crystals);
    }
}
