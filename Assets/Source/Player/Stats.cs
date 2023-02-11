using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stats : MonoBehaviour
{
    public int GetBaseStat(int stat, int level)
    {
        float tempLevel = level;
        float tempPercent = tempLevel / 10;
        float tempStat = stat * (1 + tempPercent - 0.1f);
        stat = (int)tempStat;

        return stat;
    }
}
