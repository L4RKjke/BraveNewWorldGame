using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardCreater : HeroCreater
{
    protected override void DistributeLeftStats(int leftStats, CharacterStats characterStats)
    {
        if(leftStats > 0)
            characterStats.AssignStat(0, 0, 0, leftStats);
        else
            characterStats.AssignStat(-(leftStats / 2), -(leftStats / 2 / PointToDefense), 0 , 0);
    }
}
