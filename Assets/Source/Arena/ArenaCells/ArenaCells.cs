using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ObjectsSaver))]

public class ArenaCells : MonoBehaviour
{
    [SerializeField] private List<GameObject> _playerCharacters;
    [SerializeField] private List<Cell> _cell;
    [SerializeField] private List<Barrier> _barriers;
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private NavMeshSurface2d _navMesh;
    [SerializeField] private BoxCollider2D _battleFieldNavMesh;
    [SerializeField] private GameObject _dragAndDrop;
    [SerializeField] private UnitPool _fighters;

    private ObjectsSaver _objectsSaver;
    private List<Transform> _parentCellsY = new List<Transform>();
    private int _maxEnemy = 3;
    private int _maxBarrier = 5;
    private int _height = 7;
    private int _width = 11;
    private int _playerWidth = 4;


    private void Start()
    {
        _objectsSaver = GetComponent<ObjectsSaver>();
        CreateArenaCells();
        CreateBarriers();
        CreateEnemies();
        CreateCharacters();
        HideCells(_playerWidth);
        DeleteCells(_playerWidth + 1);
        _navMesh.BuildNavMesh();
        _battleFieldNavMesh.enabled = false;
    }

    public void PlayStartBattle()
    {
        DeleteCells();
    }

    private void CreateCharacters()
    {

        for (int i = 0; i < _playerCharacters.Count; i++)
        {
            Cell cell = _objectsSaver.GetCell(i, 0);
            GameObject dragAndDrop = Instantiate(_dragAndDrop, cell.transform.position, Quaternion.identity);
            GameObject playerCharacter = Instantiate(_playerCharacters[i], new Vector2(cell.transform.position.x, cell.transform.position.y + 0.38f), Quaternion.identity);
            playerCharacter.transform.SetParent(dragAndDrop.transform);
            cell.ChangeFull();
            cell.ChangeStayCharacter();
            dragAndDrop.GetComponent<DragAndDrop>().InstantiateCell(cell);

            var newUnit = playerCharacter.transform.GetChild(1).GetComponent<Fighter>();
            ///Временно
            newUnit.Init(FighterType.Recruit, FighterType.Enemy, _fighters, 20, 150, 1.2f);

            _fighters.AddNewFighter(newUnit);
        }
    }

    private void DeleteCells(int startFolder = 0)
    {
        for (int i = startFolder; i < _objectsSaver.transform.childCount; i++)
        {
            Destroy(_objectsSaver.transform.GetChild(i).gameObject);
        }
    }

    private void HideCells(int folderHide)
    {
        for (int i = 0; i < _objectsSaver.transform.GetChild(folderHide).childCount; i++)
        {
            _objectsSaver.transform.GetChild(_playerWidth).GetChild(i).TryGetComponent<Cell>(out Cell cell);
            if (cell.IsFull == false)
            {
                cell.ChangeFull();
                cell.ChangeStayCharacter();
            }

            _objectsSaver.transform.GetChild(_playerWidth).GetChild(i).TryGetComponent<SpriteRenderer>(out SpriteRenderer sprite);
            sprite.enabled = false;
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
                cell = _objectsSaver.GetRandomCell();

                while (cell.IsFull == true)
                {
                    cell = _objectsSaver.GetRandomCell();
                }

                Barrier barrier = Instantiate(_barriers[i], cell.transform.position, Quaternion.identity);
                barrier.transform.SetParent(_objectsSaver.ParentFolderBarrier);
                cell.ChangeFull();
            }
        }
    }

    private void CreateEnemies()
    {
        int enemiesCount;
        bool canStay;
        Cell cell;

        for (int i = 0; i < _enemies.Count; i++)
        {
            enemiesCount = Random.Range(2, _maxEnemy + 1);

            for (int j = 0; j < enemiesCount; j++)
            {
                cell = _objectsSaver.GetRandomCell(_playerWidth);
                canStay = _objectsSaver.CheckCellsAround(cell.TransformX, cell.TransformY);

                while (cell.IsFull == true || canStay == false)
                {
                    cell = _objectsSaver.GetRandomCell(_playerWidth);
                    canStay = _objectsSaver.CheckCellsAround(cell.TransformX, cell.TransformY);
                }

                GameObject enemy = Instantiate(_enemies[i], cell.transform.position, Quaternion.identity);
                enemy.transform.SetParent(_objectsSaver.ParentFolderEnemy);

                var newUnit = enemy.transform.GetChild(1).GetComponent<Fighter>();
                ///Временно
                ///
                if (newUnit.TryGetComponent<RangeAtacker>(out _))
                    newUnit.Init(FighterType.Enemy, FighterType.Recruit, _fighters, 20, 150, 5f);
                else 
                    newUnit.Init(FighterType.Enemy, FighterType.Recruit, _fighters, 20, 150, 1.2f);

                _fighters.AddNewFighter(newUnit);

                cell.ChangeFull();
                cell.ChangeStayCharacter();
            }
        }
    }
}
