using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelLose : PanelRewards
{
    [SerializeField] private TMP_Text _reward;

    public void SetRewards(int gold, int exp, int currentLevel, int openedLevel)
    {
        gold = GetLevelReward(gold, currentLevel, openedLevel);
        _reward.text = gold + Lean.Localization.LeanLocalization.GetTranslationText("Common/GoldAnd") + exp
            + Lean.Localization.LeanLocalization.GetTranslationText("Common/TotalExp");
        AddRewards(gold);
    }
}
