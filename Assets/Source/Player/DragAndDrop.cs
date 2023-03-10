using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private ObjectsSaver _objectsSaver;
    [SerializeField] private Camera _camara;

    private List<Collider2D> _cells = new List<Collider2D>();
    private Cell _lastCell;
    private Vector3 _pointScreen;
    private Vector3 _offSet;

    private readonly int _distance = 1000;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _cells.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _cells.Remove(other);
    }

    private void OnMouseDown()
    {
        _pointScreen = _camara.WorldToScreenPoint(transform.position);
        _offSet = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _pointScreen.z);
        Vector3 currentPosition = _camara.ScreenToWorldPoint(currentScreenPoint);
        transform.position = currentPosition;
    }


    private void OnMouseUp()
    {
        bool isSucces = false;

        if (_lastCell != null)
            PlayerStay(_lastCell);

        while (isSucces == false && _cells.Count > 0)
        {
            isSucces = FindDistance(_cells);
        }

        if (isSucces == false)
            ReturnCharacter();
    }

    public void InstantiateCell(Cell cell)
    {
        _lastCell = cell;
    }

    private bool FindDistance(List<Collider2D> blocks)
    {
        float distance = _distance;
        int numberOfMassive = 0;
        bool canStay;

        for (int i = 0; i < blocks.Count; i++)
        {
            if (distance == _distance || Vector3.Distance(transform.position, blocks[i].transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, blocks[i].transform.position);
                numberOfMassive = i;
            }
        }

        blocks[numberOfMassive].TryGetComponent<Cell>(out Cell cell);

        if(cell.IsFull == false || _lastCell == cell)
        {
            canStay = _objectsSaver.CheckCellsAround(cell.Row,cell.Column);

            if (canStay == true)
                PutCharacter(cell);
            else
            {
                _cells.RemoveAt(numberOfMassive);
                return false;
            }    

            return true;
        }
        else
        {
            _cells.RemoveAt(numberOfMassive);
            return false;
        }
    }

    private void ReturnCharacter()
    {
        if (_lastCell != null)
            PlayerStay(_lastCell);

        transform.position = _offSet;
    }

    private void PutCharacter(Cell cell)
    {
        transform.position = cell.transform.position;
        _lastCell = cell;
        PlayerStay(cell);
    }

    private void PlayerStay(Cell cell)
    {
        cell.ChangeFull();
        cell.ChangeStayCharacter();
    }
}
