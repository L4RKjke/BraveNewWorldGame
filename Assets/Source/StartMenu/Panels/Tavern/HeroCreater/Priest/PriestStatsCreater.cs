using UnityEngine;

[CreateAssetMenu(fileName = "PriestStats", menuName = "HeroCreater/StatsCreater/PriestStatsCreater")]
public class PriestStatsCreater : HeroStatsCreater
{
    protected override void DistributeLeftStats(int leftStats, CharacterStats characterStats)
    {
        if (leftStats >= 0)
            characterStats.SetBaseStats(0, 0, leftStats / 2 * HealthToPoint, leftStats / 2, true);
        else
            characterStats.SetBaseStats(leftStats / 2, leftStats / 2 / PointToDefense, 0, 0, true);
    }
}
