using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSaveLoad : MonoBehaviour, BinarrySaveLoad
{
    [SerializeField] private CharactersStorage _charactersStorage;
    [SerializeField] private List<GameObject> _characters;
    [SerializeField] private List<HeroAppearanceCreater> _heroAppearanceCreater;
    [SerializeField] private Transform _pointToCreate;

    private List<CharacterData> _characterDatas = new List<CharacterData>();

    public void AddData(CharacterData characterData)
    {
        _characterDatas.Add(characterData);
    }

    public void DeleteData(int id)
    {
        _characterDatas.RemoveAt(id);
    }

    public void Load()
    {
        List<CharacterData> characters = BinarySavingSystem.LoadCharacter();

        for(int i = 0; i < characters.Count; i++)
        {
            GameObject newCharacter = Instantiate(_characters[characters[i].Class], _pointToCreate);
            AddData(characters[i]);
            newCharacter.transform.position = _pointToCreate.position;
            HeroAppearanceCreater heroAppearanceCreater = _heroAppearanceCreater[characters[i].Class];
            heroAppearanceCreater.CreateAppereance(newCharacter.GetComponent<Appearance>(), characters[i], false);
            newCharacter.transform.localScale = new Vector3(70f, 70f, 1);
            CharacterStats characterStats = newCharacter.GetComponent<CharacterStats>();
            characterStats.SetName(characters[i].Name);
            characterStats.AssignStat(characters[i].Attack, characters[i].Defense, characters[i].Health, characters[i].Magic);
            _charactersStorage.AddNewCharacter(newCharacter);
        }
    }

    public void Save()
    {
        for (int i = 0; i < _characterDatas.Count; i++)
        {
            BinarySavingSystem.SaveCharacter(_characterDatas[i], i);
        }
    }
}
