using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersStorage : MonoBehaviour
{
    [SerializeField] private List<GameObject> _temp; //test
    [SerializeField] private Transform _parentCharactersUI;
    [SerializeField] private CharactersSaveLoad _charactersSaveLoad;

    private List<GameObject> _characters = new List<GameObject>();

    private int _maxSizeCharacters = 8;

    public CharactersSaveLoad CharactersSaveLoad => _charactersSaveLoad;
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

    public List<int> GetTopCharactersID()
    {
        List<int> charactersIDtemp = new List<int>();
        List<int> charactersLevels = new List<int>();
        List<int> top5Characters = new List<int>();
        charactersIDtemp.Add(0);
        charactersLevels.Add(_characters[0].GetComponent<CharacterStats>().Level);

        for (int i = 1; i < _characters.Count; i++)
        { 
            for (int j = charactersLevels.Count - 1; j >= 0; j--)
            {
                if(charactersLevels[j] > _characters[i].GetComponent<CharacterStats>().Level)
                {
                    AddValue(charactersIDtemp, j + 1, i);
                    AddValue(charactersLevels, j + 1, _characters[i].GetComponent<CharacterStats>().Level);
                    break;
                }
                else if(j == 0)
                {
                    AddValue(charactersIDtemp, 0 , i);
                    AddValue(charactersLevels, 0, _characters[i].GetComponent<CharacterStats>().Level);
                    break;
                }
            }
        }

        for(int i = 0; i < 5; i++)
        {
            top5Characters.Add(charactersIDtemp[i]);

            if (charactersIDtemp.Count - 1 == i)
                break;
        }

        return top5Characters;
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

    private void AddValue(List<int> list, int startValue, int addValue)
    {
        int temp = 0;
        int temp2 = 0;

        if (list.Count == startValue)
        {
            list.Add(addValue);
            return;
        }

        temp = addValue;

        for (int i = startValue; i < list.Count; i++)
        {
            temp2 = list[i];
            list[i] = temp;
            temp = temp2;
        }

        list.Add(temp);
    }
}
