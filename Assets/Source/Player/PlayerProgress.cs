using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerProgress : MonoBehaviour
{
    public int OpenedLevel { get; private set; } = 125;

    public UnityAction NewLevelOpened;

    public void SetLevel(int level)
    {
        OpenedLevel = level;
    }

    public void LevelComplete()
    {
        OpenedLevel++;
        NewLevelOpened?.Invoke();
    }
}
