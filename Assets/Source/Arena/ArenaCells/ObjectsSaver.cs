using UnityEngine;

public class ObjectsSaver : MonoBehaviour
{
    [SerializeField] private GameObject _parentFolderCell;
    [SerializeField] private Transform _parentFolderBarrier;
    [SerializeField] private Transform _parentFolderEnemy;
    [SerializeField] private Transform _charactersFolder;

    private Cell[,] _cells = new Cell[11, 7];

    private readonly int _maxColumn = 11;
    private readonly int _maxRow = 7;

    public Transform ParentFolderBarrier => _parentFolderBarrier;

    public Transform ParentFolderEnemy => _parentFolderEnemy;

    public Transform ParentFolderCharacters => _charactersFolder;

    public GameObject ParentFolderCell => _parentFolderCell;

    public int MaxColumn => _maxColumn;

    public int MaxRow => _maxRow;

    public Cell GetCell(int column, int row)
    {
        if (column > _maxColumn - 1)
            column = _maxColumn - 1;
        if (row > _maxRow - 1)
            row = _maxRow - 1;

        return _cells[column, row];
    }

    public Cell GetRandomCell(int minColumn = 0, int minRow = 0)
    {
        var cell = _cells[Random.Range(minColumn, _maxColumn - 1), Random.Range(minRow, _maxRow - 1)];

        return cell;
    }
        

    public void AddCell(Cell cell, int x, int y)
    {
        _cells[x, y] = cell;
    }

    public bool CheckCellsAround(int x, int y)
    {
        bool canStay = true;

        if (y == 0 || GetCell(x, y - 1).IsFull == true)
        {
            if (y + 1 == transform.childCount || GetCell(x, y + 1).IsFull == true)
            {
                if (x == 0 || GetCell(x - 1, y).IsFull == true)
                {
                    if (x + 1 == transform.GetChild(y).childCount || GetCell(x + 1, y).IsFull == true)
                    {

                        canStay = CheckBuildingArround(x, y);
                    }
                }
            }
        }

        return canStay;
    }

    private bool CheckBuildingArround(int x, int y)
    {
        if (y == 0 || GetCell(x, y - 1).IsBuildingStay == true)
        {
            if (y + 1 == transform.childCount || GetCell(x, y + 1).IsBuildingStay == true)
            {
                if (x == 0 || GetCell(x - 1, y).IsBuildingStay == true)
                {
                    if (x + 1 == transform.GetChild(y).childCount || GetCell(x + 1, y).IsBuildingStay == true)
                    {
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }
}
