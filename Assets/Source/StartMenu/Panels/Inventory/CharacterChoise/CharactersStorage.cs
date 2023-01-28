using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersStorage : MonoBehaviour
{
    [SerializeField] private List<GameObject> _temp; //test
    [SerializeField] private Transform _parentCharactersUI;

    private List<GameObject> _characters = new List<GameObject>();

    private int _maxSizeCharacters = 3;

    public bool IsFree => _maxSizeCharacters > _characters.Count;
    public int AllCharacters => _characters.Count;

    private void Awake()
    {
        for (int i = 0; i < _temp.Count; i++) //test
        {
            AddNewCharacter(_temp[i]);
        }
    }

    public GameObject GetCharacter(int id)
    {
        return _characters[id];
    }

    public void AddNewCharacter(GameObject character)
    {
        _characters.Add(character);
        _characters[_characters.Count - 1].SetActive(false);
        _characters[_characters.Count - 1].transform.SetParent(_parentCharactersUI);
        _characters[_characters.Count - 1].transform.localScale = new Vector3(100f, 100f, 1);
        _characters[_characters.Count - 1].transform.position = _parentCharactersUI.position;
    }

    public void DeleteCharacter(int Id)
    {
        Destroy(_characters[Id]);
        _characters.RemoveAt(Id);
    }
}
