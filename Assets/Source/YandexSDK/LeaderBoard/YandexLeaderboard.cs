using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YandexLeaderboard : MonoBehaviour
{
    public void FormListOfTopPlayers()
    {

    }

    public void UpdateLeaderBoardOn()
    {

    }
}

public class PlayerInfoLeaderboard
{
    public string Name { get; private set; }
    public int Level { get; private set; }

    public PlayerInfoLeaderboard(string name, int level)
    {
        Name = name;
        Level = level;
    }
}
