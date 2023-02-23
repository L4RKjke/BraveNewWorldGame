using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnd : Condition
{
    [SerializeField] private FinalPanels _panels;

    private void OnEnable()
    {
        _panels.BattleEnd += OnBattleEnd;
    }

    private void OnDisable()
    {
        _panels.BattleEnd -= OnBattleEnd;
    }

    private void OnBattleEnd()
    {
        NeedTransit = true;
    }
}
