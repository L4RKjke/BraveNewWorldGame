using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterStorage))]
public class PanelHunt : RenderUI
{
    [SerializeField] private List<LevelInfo> _levels;

    private MonsterStorage _monsterStorage;
    private int _currentLevel = 1;

    private void Awake()
    {
        _monsterStorage = GetComponent<MonsterStorage>();
        AddGraphics();
    }

    public void ChangeLevel(int id)
    {
        _currentLevel += id;

        DeleteAllButtons();
        AddGraphics();
    }

    protected override void AddGraphics()
    {
        LevelMonsterInfo levelMonsterInfo;

        for(int i = 0; i < _levels[_currentLevel - 1].GetCountTypes(); i++)
        {
            levelMonsterInfo = _levels[_currentLevel - 1].GetMonsterInfo(i);
            GameObject newMonsterView = Instantiate(Content, Container.transform) as GameObject;
            MonsterInfo monsterInfo = _monsterStorage.GetMonsterInfo(levelMonsterInfo.MonsterId);
            newMonsterView.GetComponent<MonsterPanelView>().Init(monsterInfo.Sprite, levelMonsterInfo.Count);
        }
    }
}

[System.Serializable]
public class LevelInfo
{
    [SerializeField] private List<LevelMonsterInfo> _monstersInfo;

    public int GetCountTypes()
    {
        return _monstersInfo.Count;
    }

    public LevelMonsterInfo GetMonsterInfo(int id)
    {
        return _monstersInfo[id];
    }
}

[System.Serializable]
public class LevelMonsterInfo
{
    [SerializeField] private int _monsterID;
    [SerializeField] private int _count;

    public int MonsterId => _monsterID;
    public int Count => _count;
}
