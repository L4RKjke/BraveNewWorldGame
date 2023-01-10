using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSaver : MonoBehaviour
{
    [SerializeField] private GameObject _parentFolderCell;
    [SerializeField] private Transform _parentFolderBarrier;
    [SerializeField] private Transform _parentFolderEnemy;

    public Transform ParentFolderBarrier => _parentFolderBarrier;
    public Transform ParentFolderEnemy => _parentFolderEnemy;
    public GameObject ParentFolderCell => _parentFolderCell;

    public Cell GetRandomCell(int minNumberFolder = 0)
    {
        int numberCells1;
        int numberCells2;
        Transform numberFolderCell;
        Transform currentCell;

        numberCells1 = Random.Range(minNumberFolder, transform.childCount);
        numberFolderCell = transform.GetChild(numberCells1);
        numberCells2 = Random.Range(0, numberFolderCell.childCount);
        currentCell = numberFolderCell.GetChild(numberCells2);

        currentCell.TryGetComponent(out Cell cell);

        return cell;
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

    private Cell GetCell(int x, int y)
    {
        transform.GetChild(y).GetChild(x).TryGetComponent<Cell>(out Cell cell);

        return cell;
    }
}
