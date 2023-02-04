using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewCharactersTest : MonoBehaviour
{
    [SerializeField] private CharactersStorage _storage;
    [SerializeField] private Button[] _sellectButtons;
    [SerializeField] private Button[] _removeButtons;
    [SerializeField] private GameObject[] _charPositions;
    [SerializeField] private ArenaCells _arenaCells;
    [SerializeField] private GameObject _dragAndDrop;

    private List<GameObject> _playerUnits = new List<GameObject>();

    public void OnEnable()
    {
        for (int i = 0; i < _sellectButtons.Length - 1; i++)
        {
            _sellectButtons[i].onClick.AddListener(() => OnSelectButtonClick(0));
            _removeButtons[i].onClick.AddListener(() => OnReturnButtonClick(0));
        }


        for (int i = 0; i < _storage.GetLenght(); i++)
        {
            if (_storage.GetLenght() == i)
                break;

            _playerUnits.Add(Instantiate(_storage.GetCharacter(i), new Vector2(_sellectButtons[i].transform.position.x, _sellectButtons[i].transform.position.y - 0.4f), Quaternion.identity));
            _playerUnits[i].transform.localScale = Vector3.one * 0.55f;
            _playerUnits[i].SetActive(true);
            _playerUnits[i].transform.SetParent(_charPositions[i].transform);
        }
    }

    private void OnDisable()
    {
        _playerUnits.Clear();
    }

    private void OnSelectButtonClick(int id)
    {
        _playerUnits[id].transform.position = _arenaCells.GetCellPosition();
        GameObject dragAndDrop = Instantiate(_dragAndDrop, _playerUnits[id].transform.position, Quaternion.identity);
        _playerUnits[id].transform.SetParent(dragAndDrop.transform);
        _arenaCells.GetCell().ChangeFull();
        _arenaCells.GetCell().ChangeStayCharacter();
        dragAndDrop.GetComponent<DragAndDrop>().InstantiateCell(_arenaCells.GetCell());
        _playerUnits[id].transform.localScale *= 2;
        _sellectButtons[0].gameObject.SetActive(false);
        _removeButtons[0].gameObject.SetActive(true);
        _arenaCells.AddCharacter(0);
    }

    private void OnReturnButtonClick(int id)
    {
        _playerUnits[id].transform.position = new Vector2(_sellectButtons[id].transform.position.x, _sellectButtons[id].transform.position.y - 0.4f);
        _sellectButtons[0].gameObject.SetActive(true);
        _playerUnits[id].transform.localScale /= 2;
        _removeButtons[0].gameObject.SetActive(false);
        _arenaCells.RemoveCharacter(0);
    }
}
