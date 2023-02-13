using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersArena : MonoBehaviour
{
    private List<int> _lastCharactersID = new List<int>();

    public ArenaCells ArenaCells { get; private set; }

    public List<int> GetIDs()
    {
        return _lastCharactersID;
    }

    public void AddCharacters()
    {
        for (int i = 0; i < _lastCharactersID.Count; i++)
        {
            ArenaCells.AddCharacter(_lastCharactersID[i]);
        }

        ArenaCells.CreateCharacters();
    }

    public void AddLastCharacterID(int characterID)
    {
        _lastCharactersID.Add(characterID);
    }

    public bool CheckId(int id)
    {
        bool isAdded = false;

        for (int i = 0; i < _lastCharactersID.Count; i++)
        {
            if (id == _lastCharactersID[i])
            {
                isAdded = true;
                return isAdded;
            }
        }

        return isAdded;
    }

    public void ClearIDs()
    {
        _lastCharactersID.Clear();
    }

    public void Init(CharactersStorage charactersStorage, ArenaCells arenaCells)
    {
        _lastCharactersID = charactersStorage.GetTopCharactersID();
        ArenaCells = arenaCells;
    }
}
