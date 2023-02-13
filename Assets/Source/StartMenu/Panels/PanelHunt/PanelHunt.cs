using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(MonsterStorage))]
public class PanelHunt : RenderUI
{
    [SerializeField] private List<LevelInfo> _levels;
    [SerializeField] private PlayerProgress _progress;
    [SerializeField] private TMP_Text _levelView;

    private MonsterStorage _monsterStorage;
    private int _currentLevel = 1;

    private void Awake()
    {
        _monsterStorage = GetComponent<MonsterStorage>();
        SetLastLevel();
    }

    private void OnEnable()
    {
        _progress.NewLevelOpened += SetLastLevel;
    }

    private void OnDisable()
    {
        _progress.NewLevelOpened -= SetLastLevel;
    }

    public List<GameObject> GetAllEnemies()
    {
        List<GameObject> enemies = new List<GameObject>();
        LevelMonsterInfo levelMonsterInfo;
        int id = CheckLevelInfo(_currentLevel - 1);

        for (int i = 0; i < _levels[id].GetCountTypes(); i++)
        {
            levelMonsterInfo = _levels[id].GetMonsterInfo(i);

            for (int j = 0; j < levelMonsterInfo.Count; j++)
            {
                enemies.Add(_monsterStorage.GetMonster(levelMonsterInfo.MonsterId));
            }
        }

        return enemies;
    }    

    public int GetCurrentLevel()
    {
        return _currentLevel;
    }

    public void ChangeLevel(int id)
    {
        _currentLevel += id;
        _currentLevel = Mathf.Clamp(_currentLevel, 1, _progress.OpenedLevel);
        LevelChangeText();
    }

    protected override void AddGraphics()
    {
        LevelMonsterInfo levelMonsterInfo;

        int id = CheckLevelInfo(_currentLevel - 1);

        for (int i = 0; i < _levels[id].GetCountTypes(); i++)
        {
            levelMonsterInfo = _levels[id].GetMonsterInfo(i);
            GameObject newMonsterView = Instantiate(Content, Container.transform) as GameObject;
            MonsterInfo monsterInfo = _monsterStorage.GetMonsterInfo(levelMonsterInfo.MonsterId);
            newMonsterView.GetComponent<MonsterPanelView>().Init(monsterInfo.Sprite, levelMonsterInfo.Count);
        }
    }

    private int CheckLevelInfo(int id)
    {
        while (id >= _levels.Count)
            id -= _levels.Count;

        return id;
    }

    private void SetLastLevel()
    {
        _currentLevel = _progress.OpenedLevel;
        LevelChangeText();
        DeleteAllButtons();
        AddGraphics();
    }

    private void LevelChangeText()
    {
        _levelView.text = _currentLevel.ToString();
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
