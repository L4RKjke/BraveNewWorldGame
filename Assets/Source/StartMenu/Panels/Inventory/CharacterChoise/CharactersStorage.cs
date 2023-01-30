using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersStorage : MonoBehaviour
{
    [SerializeField] private List<GameObject> _temp; //test
    [SerializeField] private Transform _parentCharactersUI;

    private List<GameObject> _characters = new List<GameObject>();

    private int _maxSizeCharacters = 8;

    public bool IsFree => _maxSizeCharacters > _characters.Count;
    public int AllCharacters => _characters.Count;

    private void Awake()
    {
        for (int i = 0; i < _temp.Count; i++) //test
        {
            GameObject character = Instantiate(_temp[i]);
            _characters.Add(character);
            ReturnCharacter(_characters.Count - 1);
        }
    }

    public GameObject GetCharacter(int id)
    {
        return _characters[id];
    }

    public void AddNewCharacter(GameObject character)
    {
        _characters.Add(character);
        ReturnCharacter(_characters.Count - 1);
    }

    public void DeleteCharacter(int Id)
    {
        Destroy(_characters[Id]);
        _characters.RemoveAt(Id);
    }

    public void ReturnCharacter(int id)
    {
        _characters[id].SetActive(false);
        _characters[id].transform.SetParent(_parentCharactersUI);
        _characters[id].transform.localScale = new Vector3(100f, 100f, 1);
        _characters[id].transform.position = _parentCharactersUI.position;
    }
}
