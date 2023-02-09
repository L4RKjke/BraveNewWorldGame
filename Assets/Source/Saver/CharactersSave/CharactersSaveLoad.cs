using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSaveLoad : MonoBehaviour, BinarrySaveLoad
{
    [SerializeField] private CharactersStorage _charactersStorage;
    [SerializeField] private List<GameObject> _characters;
    [SerializeField] private List<HeroAppearanceCreater> _heroAppearanceCreater;
    [SerializeField] private Transform _pointToCreate;

    private List<CharacterData> _charactersData = new List<CharacterData>();

    public void AddData(CharacterData characterData)
    {
        _charactersData.Add(characterData);
    }

    public void DeleteData(int id)
    {
        _charactersData.RemoveAt(id);
    }

    public void Load()
    {
        _charactersData = BinarySavingSystem.LoadCharacter();

        for(int i = 0; i < _charactersData.Count; i++)
        {
            GameObject newCharacter = Instantiate(_characters[_charactersData[i].Class], _pointToCreate);
            newCharacter.transform.position = _pointToCreate.position;
            HeroAppearanceCreater heroAppearanceCreater = _heroAppearanceCreater[_charactersData[i].Class];
            heroAppearanceCreater.CreateAppereance(newCharacter.GetComponent<Appearance>(), _charactersData[i], false);
            newCharacter.transform.localScale = new Vector3(70f, 70f, 1);
            CharacterStats characterStats = newCharacter.GetComponent<CharacterStats>();
            characterStats.SetName(_charactersData[i].Name);
            characterStats.SetBaseStats(_charactersData[i].Attack, _charactersData[i].Defense, _charactersData[i].Health, _charactersData[i].Magic);
            characterStats.GetExpirience(_charactersData[i].Exp, 1);
            _charactersStorage.AddNewCharacter(newCharacter);
        }
    }

    public void Save()
    {
        for (int i = 0; i < _charactersStorage.AllCharacters; i++)
        {
            _charactersData[i].SetExp(_charactersStorage.GetCharacter(i).GetComponent<CharacterStats>().Exp);
        }

        BinarySavingSystem.SaveCharacters(_charactersData);
    }
}
