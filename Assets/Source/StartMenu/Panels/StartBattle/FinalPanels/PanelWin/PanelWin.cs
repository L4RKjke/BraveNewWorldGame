using TMPro;
using UnityEngine;

public class PanelWin : PanelRewards
{
    [SerializeField] private TMP_Text _textComplete;

    public override void SetRewards(int gold,int exp, int currentLevel, int openedLevel)
    {
        int minCrystals = 50;
        int maxCrystals = 80;
        int crystals = Random.Range(minCrystals, maxCrystals);

        AddRewards(gold, crystals, currentLevel, openedLevel, exp);

        SetLevelComplete(currentLevel);
    }

    private void SetLevelComplete(int currentLevel)
    {
        _textComplete.text = Lean.Localization.LeanLocalization.GetTranslationText("Common/Level") + " " + currentLevel
        + Lean.Localization.LeanLocalization.GetTranslationText("Common/Complete") + "!";
    }
}
