using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersStorage : MonoBehaviour
{
    [SerializeField] private List<GameObject> _temp; //test

    private List<GameObject> _characters = new List<GameObject>();

    private int _maxSizeCharacters = 2;

    public bool _isFree => _maxSizeCharacters > _characters.Count;

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
        _characters[_characters.Count - 1].transform.SetParent(gameObject.GetComponent<CharacterChoiceUI>().GetParent());
    }

    public void DeleteCharacter(int Id)
    {
        _characters.RemoveAt(Id);
    }
}
