using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject _foldingScreen;
    [SerializeField] private CharactersItemUI _charactersItemUI;
    [SerializeField] private StatsUI _statsUI;
    [SerializeField] private CharacterChoiceUI _characterChoice;
    [SerializeField] private CharactersStorage _characterStorage;
    [SerializeField] private LevelUI _level;
    [SerializeField] private DescriptionCharacterUI _descriptionCharacterUI;

    private GameObject _currentCharacter;
    private int _currentId = 0;
    private Coroutine _coroutine;

    public int CurrentId => _currentId;

    public void GetLevelTEST()
    {
        _characterStorage.GetCharacter(_currentId).GetComponent<CharacterStats>().GetExpirience(1000, _characterStorage.GetCharacter(_currentId).GetComponent<CharacterStats>().Level);
    }

    private void Awake()
    {
        _characterChoice.Init(_characterStorage);
        _characterChoice.enabled = true;
        _currentCharacter = _characterStorage.GetCharacter(0);
        _descriptionCharacterUI.Init(_currentCharacter.transform.GetChild(1).GetComponents<Ability>().Length);
        SetAbilitiesDescription(_currentCharacter);
        _descriptionCharacterUI.SetDescriptionClass(_currentCharacter);
        _statsUI.Init();
    }

    private void Start()
    {
        _charactersItemUI.UpdateAllButtons(_characterStorage.GetCharacter(_currentId));
        _statsUI.UpdateName(_characterStorage.GetCharacter(_currentId).GetComponent<CharacterStats>().Name);
    }

    private void OnEnable()
    {
        float delay = 0.5f;
        _coroutine = StartCoroutine(Delay(delay));

        if (_currentCharacter != _characterStorage.GetCharacter(_currentId))
        {
            _currentCharacter = _characterStorage.GetCharacter(_currentId);
            _charactersItemUI.UpdateAllButtons(_characterStorage.GetCharacter(_currentId));
            ShowStats();
            _statsUI.UpdateName(_characterStorage.GetCharacter(_currentId).GetComponent<CharacterStats>().Name);
        }
        else if(_currentCharacter != null)
        {
            ShowStats();
        }
    }

    private void OnDisable()
    {
        _currentCharacter.SetActive(false);
    }

    public void SetCurrentCharacter(int newID)
    {
        _characterChoice.ChoisedCharacter(newID, _currentId);
        _currentId = newID;
        SetCharacter();
    }

    public void SelectCharacter(int next)
    {
        _currentId += next;

        if (_currentId == _characterStorage.AllCharacters)
        {
            _currentId = 0;
            _characterChoice.ChoisedCharacter(_currentId, _characterStorage.AllCharacters - 1);
        }
        else if (_currentId < 0)
        {
            _currentId = _characterStorage.AllCharacters - 1;
            _characterChoice.ChoisedCharacter(_currentId, 0);
        }
        else
        {
            _characterChoice.ChoisedCharacter(_currentId, _currentId - next);
        }

        SetCharacter();
    }

    public void EquipItem(ItemType type, bool isWear, Item item, bool isHand = false)
    {
        _characterStorage.GetCharacter(_currentId).GetComponent<CharacterItems>().ChangeItem(type, isWear, item, isHand);
        ShowStats();
        _characterChoice.UpdateHead(_currentId);
    }

    private void SetCharacter()
    {
        GameObject character = _characterStorage.GetCharacter(_currentId);
        _charactersItemUI.UpdateAllButtons(character);
        ShowStats();
        _statsUI.UpdateName(character.GetComponent<CharacterStats>().Name);

        SetAbilitiesDescription(character);
        _descriptionCharacterUI.SetDescriptionClass(character);

        _foldingScreen.SetActive(false);
        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(Delay(0));
    }

    private void ShowStats()
    {
        CharacterStats characterStats = _characterStorage.GetCharacter(_currentId).GetComponent<CharacterStats>();
        _level.SetLevel(characterStats);
        _statsUI.UpdateAllStats(characterStats.Attack, characterStats.Defense, characterStats.Health, characterStats.Magic);
    }

    private void ShowCharacter()
    {
        _currentCharacter.SetActive(false);
        _currentCharacter = _characterStorage.GetCharacter(_currentId);
        _currentCharacter.SetActive(true);
    }

    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);

        _foldingScreen.SetActive(true);
        float delayScreen = 0.25f;
        yield return new WaitForSeconds(delayScreen);

        ShowCharacter();
    }

    private void SetAbilitiesDescription(GameObject character)
    {
        Ability[] abilities = character.transform.GetChild(1).GetComponents<Ability>();

        for (int i = 0; i < abilities.Length; i++)
        {
            _descriptionCharacterUI.UpdateAbility(i, abilities[i]);
        }
    }
}
