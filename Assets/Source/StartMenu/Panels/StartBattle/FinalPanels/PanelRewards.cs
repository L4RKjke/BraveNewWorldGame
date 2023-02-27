using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelRewards : MonoBehaviour
{
    [SerializeField] private TMP_Text _gold;
    [SerializeField] private TMP_Text _crystals;
    [SerializeField] private TMP_Text _exp;


    protected PlayerWallet _playerWallet;

    public void Init(PlayerWallet wallet)
    {
        _playerWallet = wallet;
    }

    public virtual void SetRewards(int gold, int exp, int currentLevel, int openedLevel)
    {
        AddRewards(gold, 0, currentLevel, openedLevel, exp);
    }

    protected void AddRewards(int gold,int crystals, int currentLevel, int openedLevel, int exp)
    {
        gold = GetLevelReward(gold, currentLevel, openedLevel);
        crystals = GetLevelReward(crystals, currentLevel, openedLevel);

        _playerWallet.ChangeGold(gold);
        _playerWallet.ChangeCrystals(crystals);
        SetReward(gold, crystals, exp);
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

    private void SetReward(int gold, int crystals, int exp)
    {
        _gold.text = gold.ToString();
        _crystals.text = crystals.ToString();
        _exp.text = exp.ToString();
    }
}
