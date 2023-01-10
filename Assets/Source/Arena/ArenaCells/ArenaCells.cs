using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ObjectsSaver))]
public class ArenaCells : MonoBehaviour
{
    [SerializeField] private List<Cell> _cell;
    [SerializeField] private List<Barrier> _barriers;
    [SerializeField] private List<EnemyTest> _enemies;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private GameObject _navMesh;


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
        HideCells(_playerWidth);
        //_objectsSaver.DeleteCells(_playerWidth + 1);
        //_navMesh.GetComponent<NavMeshSurface2d>().BuildNavMesh();
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
            sprite.sortingOrder = -100;
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
                Cell cell = Instantiate(_cell[numberCell],position,Quaternion.identity);
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
            barriersCount = Random.Range(1, _maxBarrier + 1 + 3);

            for(int j = 0; j < barriersCount; j++)
            {
                cell = _objectsSaver.GetRandomCell();

                while (cell.IsFull == true)
                {
                    cell = _objectsSaver.GetRandomCell();
                }

                Barrier barrier = Instantiate(_barriers[i],cell.transform.position, Quaternion.identity);
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

            for(int j = 0; j < enemiesCount; j++)
            {
                cell = _objectsSaver.GetRandomCell(_playerWidth);
                canStay = _objectsSaver.CheckCellsAround(cell.TransformX,cell.TransformY);

                while (cell.IsFull == true || canStay == false)
                {
                    cell = _objectsSaver.GetRandomCell(_playerWidth);
                    canStay = _objectsSaver.CheckCellsAround(cell.TransformX, cell.TransformY);
                }

                EnemyTest enemy = Instantiate(_enemies[i], cell.transform.position, Quaternion.identity);
                enemy.transform.SetParent(_objectsSaver.ParentFolderEnemy);
                cell.ChangeFull();
                cell.ChangeStayCharacter();
            }
        }
    }
}