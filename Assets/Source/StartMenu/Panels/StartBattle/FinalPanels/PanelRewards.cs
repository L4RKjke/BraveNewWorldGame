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

    protected void AddRewards(int gold,int crystals = 0)
    {
        _playerWallet.ChangeGold(gold);
        _playerWallet.ChangeCrystals(crystals);
    }

    protected int GetLevelReward(int reward, int currentLevel, int openedLevel)
    {
        float levelDifference = currentLevel - openedLevel;

        if(levelDifference != 0)
        {
            float percentLevelDifference = levelDifference / 50;
            percentLevelDifference = Mathf.Clamp(percentLevelDifference, -1, 0);
            float tempReward = reward * (1 + percentLevelDifference);
            reward = (int)tempReward;
        }

        return reward;
    }
}
