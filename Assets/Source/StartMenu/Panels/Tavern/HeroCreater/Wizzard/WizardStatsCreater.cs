using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WizardStats", menuName = "HeroCreater/StatsCreater/WizardStatsCreater")]
public class WizardStatsCreater : HeroStatsCreater
{
    protected override void DistributeLeftStats(int leftStats, CharacterStats characterStats)
    {
        if(leftStats >= 0)
            characterStats.SetBaseStats(0, 0, 0, leftStats, true);
        else
            characterStats.SetBaseStats(leftStats / 2, leftStats / 2 / PointToDefense, 0 , 0, true);
    }
}
