using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelWin : PanelRewards
{
    [SerializeField] private TMP_Text _gold;
    [SerializeField] private TMP_Text _crystals;
    [SerializeField] private TMP_Text _exp;

    public void SetGoldAndCrystals(int gold, int currentLevel, int openedLevel)
    {
        int minCrystals = 50;
        int maxCrystals = 80;
        int crystals = Random.Range(minCrystals, maxCrystals);

        gold = GetLevelReward(gold, currentLevel, openedLevel);
        crystals = GetLevelReward(crystals, currentLevel, openedLevel);
        _gold.text = gold.ToString(); ;
        _crystals.text = crystals.ToString();
        AddRewards(gold,crystals);
    }

    public void SetExpirience(int exp)
    {
        _exp.text = "Exp " + exp;
    }
}