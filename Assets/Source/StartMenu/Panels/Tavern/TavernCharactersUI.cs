using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernCharactersUI : MonoBehaviour
{
    [SerializeField] private Transform _pointToCreate;
    [SerializeField] private StatsUI _statsUI;
    [SerializeField] private GameObject _foldingScreen;


    public CharacterStats ShowCharacter(GameObject character, HeroAppearanceCreater appereance)
    {
        GameObject newCharacter = Instantiate(character, _pointToCreate);
        newCharacter.transform.position = _pointToCreate.position;
        appereance.CreateAppereance(newCharacter.GetComponent<Appearance>());
        CharacterStats characterStats = newCharacter.GetComponent<CharacterStats>();
        newCharacter.transform.localScale = new Vector3(50f, 50f, 1);
        return characterStats;
    }
}
