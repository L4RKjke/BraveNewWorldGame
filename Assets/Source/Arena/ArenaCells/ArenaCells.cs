using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ObjectsSaver))]
[RequireComponent(typeof(UnitPool))]
public class ArenaCells : MonoBehaviour
{
    [SerializeField] private List<Cell> _cell;
    [SerializeField] private List<Barrier> _barriers;
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private NavMeshSurface2d _navMesh;
    [SerializeField] private GameObject _dragAndDrop;
    [SerializeField] private CharactersStorage _charactersStorage;
    [SerializeField] private PanelHunt _panelHunt;
    [SerializeField] private FinalPanels _finalPanels;

    private List<GameObject> _playerCharacters = new List<GameObject>();
    private List<int> _lastCharactersID = new List<int>();
    private UnitPool _fighters;
    private ObjectsSaver _objectsSaver;
    private List<Transform> _parentCellsY = new List<Transform>();
    private int _maxBarrier = 5;
    private int _height = 7;
    private int _width = 11;

    private void Awake()
    {
        _fighters = GetComponent<UnitPool>();
        _objectsSaver = GetComponent<ObjectsSaver>();
        _lastCharactersID = _charactersStorage.GetTopCharactersID();

        PrepareArena();
    }

    private void OnEnable()
    {
        _navMesh.BuildNavMesh();
    }

    public void BuildBanMesh()
    {
        _navMesh.BuildNavMesh();
    }

    public bool CheckId(int id)
    {
        bool isAdded = false;

        for(int i = 0; i < _lastCharactersID.Count; i++)
        {
            if(id == _lastCharactersID[i])
            {
                isAdded = true;
                return isAdded;
            }
        }

        return isAdded;
    }

    public void ResetLastParty()
    {
        ResetCellsCollider();

        for(int i = 0; i < _playerCharacters.Count; i++)
        {
            _fighters.RemoveLast();
        }

        _objectsSaver.ClearCharacters();
        _lastCharactersID.Clear();
        _playerCharacters.Clear();
    }

    public void PrepareArena()
    {
        _playerCharacters.Clear();
        DeleteArena();
        CreateArenaCells();
        CreateBarriers();
        CreateEnemies();
        AddCharacters();
    }

    public void AddCharacters()
    {
        for (int i = 0; i < _lastCharactersID.Count; i++)
        {
            _playerCharacters.Add(_charactersStorage.GetCharacter(_lastCharactersID[i]));
        }

        CreateCharacters();
    }

    public void AddLastCharacterID(int characterID)
    {
        _lastCharactersID.Add(characterID);
    }

    public void PlayStartBattle()
    {
        HideCells();
    }

    public void DeleteArena()
    {
        for (int i = 0; i < _parentCellsY.Count; i++)
        {
            Destroy(_parentCellsY[i].gameObject);
        }

        for (int i = 0; i < _objectsSaver.ParentFolderBarrier.transform.childCount; i++)
        {
            Destroy(_objectsSaver.ParentFolderBarrier.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < _objectsSaver.ParentFolderCharacters.transform.childCount; i++)
        {
            Destroy(_objectsSaver.ParentFolderCharacters.transform.GetChild(i).gameObject);
        }

        _parentCellsY.Clear();
    }

    public void CreateCharacters()
    {
        for (int i = 0; i < _playerCharacters.Count; i++)
        {
            Cell cell = _objectsSaver.GetCell(0, i);
            InitCharacter(i, cell);
        }
    }

    private void HideCells(int startFolder = 0)
    {
        for (int i = startFolder; i < _objectsSaver.transform.childCount; i++)
        {
            for (int j = 0; j < _objectsSaver.transform.GetChild(i).childCount; j++)
            {
                _objectsSaver.transform.GetChild(i).GetChild(j).TryGetComponent<SpriteRenderer>(out SpriteRenderer sprite);
                sprite.enabled = false;
            }
        }
    }

    private void CreateArenaCells()
    {
        int numberCell = 0;
        Transform temp = _objectsSaver.ParentFolderCell.transform;
        int parrentY = 0;
        float _stepY = _cell[0].transform.localScale.y;
        float _stepX = _cell[0].transform.localScale.x;
        Vector3 position = _startPosition;

        for (int i = 0; i < _width; i++)
        {
            Transform folder = Instantiate(temp);
            _parentCellsY.Add(folder);


            for (int j = 0; j < _height; j++)
            {
                Cell cell = Instantiate(_cell[numberCell], position, Quaternion.identity);
                cell.transform.SetParent(_parentCellsY[parrentY]);
                position.y += _stepY;
                numberCell++;
                cell.Init(j, parrentY);

                if (numberCell == _cell.Count)
                    numberCell = 0;

                if (i >= 4)
                {
                    cell.Collider.enabled = false;
                    cell.SpriteRenderer.enabled = false;
                }

                _objectsSaver.AddCell(cell, i, j);
            }

            _parentCellsY[parrentY].SetParent(transform);
            position.y = _startPosition.y;
            position.x += _stepX;
            parrentY++;
        }
    }

    private void CreateBarriers()
    {
        int barriersCount;
        Cell cell;

        for (int i = 0; i < _barriers.Count; i++)
        {
            barriersCount = Random.Range(1, _maxBarrier + 1);

            for (int j = 0; j < barriersCount; j++)
            {
                cell = _objectsSaver.GetRandomCell(1);

                while (cell.IsFull == true)
                {
                    cell = _objectsSaver.GetRandomCell(1);
                }

                Barrier barrier = Instantiate(_barriers[i], cell.transform.position, Quaternion.identity);
                barrier.transform.SetParent(_objectsSaver.ParentFolderBarrier);
                InitCell(cell);
            }
        }
    }

    private void CreateEnemies()
    {
        int currentWidth = 0;
        int meleeEnemyWidth = 5;
        int RangeEnemeWidth = 7;
        bool canStay;
        Cell cell;

        _enemies.Clear();
        _enemies = _panelHunt.GetAllEnemies();

        for (int i = 0; i < _enemies.Count; i++)
        {
            var newUnit = _enemies[i].transform.GetChild(1).GetComponent<Fighter>();

            if (newUnit.TryGetComponent<IRangeAtacker>(out _))
                currentWidth = RangeEnemeWidth;
            else
                currentWidth = meleeEnemyWidth;

            cell = _objectsSaver.GetRandomCell(currentWidth);
            canStay = _objectsSaver.CheckCellsAround(cell.Row, cell.Column);

            while (cell.IsFull == true || canStay == false)
            {
                cell = _objectsSaver.GetRandomCell(currentWidth);
                canStay = _objectsSaver.CheckCellsAround(cell.Row, cell.Column);
            }

            InitEnemy(i, cell);
            InitCell(cell);
        }
    }

    private void ResetCellsCollider()
    {
        Cell cell;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                cell =  _objectsSaver.GetCell(i, j);

                if(cell.IsFull == true && cell.IsBuildingStay == false)
                {
                    InitCell(cell);
                }
            }
        }
    }

    private void InitCell(Cell cell)
    {
        cell.ChangeFull();
        cell.ChangeStayCharacter();
    }

    private void InitEnemy(int i, Cell cell)
    {
        int level = _panelHunt.GetCurrentLevel();
        GameObject enemy = Instantiate(_enemies[i], cell.transform.position, Quaternion.identity);
        enemy.transform.SetParent(_objectsSaver.ParentFolderEnemy);
        var newEnemy = enemy.transform.GetChild(1).GetComponent<Fighter>();
        MonsterInfo monsterInfo = enemy.GetComponent<MonsterInfo>();
        newEnemy.Init(FighterType.Enemy, FighterType.Recruit, _fighters, monsterInfo.GetBaseStat(monsterInfo.Attack, level), monsterInfo.GetBaseStat(monsterInfo.Health, level));
        _finalPanels.AddRewards(monsterInfo.Gold, monsterInfo.Exp);
        _fighters.AddNewFighter(newEnemy);
    }

    private void InitCharacter(int i, Cell cell)
    {
        GameObject dragAndDrop = Instantiate(_dragAndDrop, cell.transform.position, Quaternion.identity);
        GameObject playerCharacter = Instantiate(_playerCharacters[i], new Vector3(cell.transform.position.x, cell.transform.position.y), Quaternion.identity);
        playerCharacter.transform.SetParent(dragAndDrop.transform);
        dragAndDrop.transform.SetParent(_objectsSaver.ParentFolderCharacters);
        InitCell(cell);
        dragAndDrop.GetComponent<DragAndDrop>().InstantiateCell(cell);
        playerCharacter.GetComponent<CharacterInit>().enabled = true;
        playerCharacter.transform.localScale = Vector3.one;
        playerCharacter.SetActive(true);
        CharacterStats stats = _playerCharacters[i].GetComponent<CharacterStats>();
        var newUnit = playerCharacter.transform.GetChild(1).GetComponent<Recruit>();
        newUnit.Init(FighterType.Recruit, FighterType.Enemy, _fighters, stats.Attack, stats.Health, stats.Magic, stats.Defense);
        _fighters.AddNewFighter(newUnit);
    }
}
