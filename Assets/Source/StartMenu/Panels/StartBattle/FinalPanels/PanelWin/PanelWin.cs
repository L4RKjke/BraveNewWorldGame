using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelWin : PanelRewards
{
    [SerializeField] private TMP_Text _gold;
    [SerializeField] private TMP_Text _crystals;
    [SerializeField] private TMP_Text _exp;

    public void SetGoldAndCrystals(int gold)
    {
        int minCrystals = 50;
        int maxCrystals = 80;
        int crystals = Random.Range(minCrystals, maxCrystals);

        _gold.text = gold.ToString(); ;
        _crystals.text = crystals.ToString();
    }

    public void SetExpirience(int exp)
    {
        _exp.text = "Exp " + exp;
    }
}
