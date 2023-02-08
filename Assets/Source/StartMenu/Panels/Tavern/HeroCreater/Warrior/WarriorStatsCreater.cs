using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStats", menuName = "HeroCreater/StatsCreater/WarriorStatsCreater")]
public class WarriorStatsCreater : HeroStatsCreater
{
    protected override void DistributeLeftStats(int leftStats, CharacterStats characterStats)
    {
        if (leftStats >= 0)
            characterStats.SetBaseStats(0, leftStats / 2 / PointToDefense, leftStats / 2 * HealthToPoint, 0, true);
        else
            characterStats.SetBaseStats(leftStats / 2, 0, 0, leftStats / 2, true);
    }
}
