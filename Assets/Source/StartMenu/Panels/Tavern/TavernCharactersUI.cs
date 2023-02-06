using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernCharactersUI : MonoBehaviour
{
    [SerializeField] private Transform _pointToCreate;
    [SerializeField] private StatsUI _statsUI;
    [SerializeField] private GameObject _foldingScreen;

    public Transform PointToCreate => _pointToCreate;
    private GameObject _currentCharacter;

    public GameObject GetCharacter()
    {
        return _currentCharacter;
    }

    public GameObject ShowCharacter(GameObject character)
    {
        GameObject newCharacter = Instantiate(character, _pointToCreate);
        newCharacter.transform.position = _pointToCreate.position;
        newCharacter.transform.localScale = new Vector3(70f, 70f, 1);

        _currentCharacter = newCharacter;

        return newCharacter;
    }
}
