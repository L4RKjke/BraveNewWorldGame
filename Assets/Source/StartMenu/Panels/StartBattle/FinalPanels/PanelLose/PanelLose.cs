using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelLose : PanelRewards
{
    [SerializeField] private TMP_Text _reward;

    public void SetRewards(int gold, int exp)
    {
        _reward.text = gold + " gold and " + exp + " total exp";
        AddRewards(gold);
    }
}
