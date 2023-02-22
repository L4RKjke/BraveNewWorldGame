using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelWin : PanelRewards
{
    [SerializeField] private TMP_Text _gold;
    [SerializeField] private TMP_Text _crystals;
    [SerializeField] private TMP_Text _exp;
    [SerializeField] private TMP_Text _textComplete;

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

        SetLevelComplete(currentLevel);
    }

    public void SetExpirience(int exp)
    {
        _exp.text = "EXP " + exp;
    }

    private void SetLevelComplete(int currentLevel)
    {
        _textComplete.text = Lean.Localization.LeanLocalization.GetTranslationText("Common/Level") + " " + currentLevel
        + Lean.Localization.LeanLocalization.GetTranslationText("Common/Complete");
    }
}
