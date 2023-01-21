using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayerUI : MonoBehaviour
{
    [SerializeField] private Transform _pointToCreate;
    [SerializeField] private GameObject _foldingScreen;
    [SerializeField] private CharactersItemUI _charactersItemUI;
    [SerializeField] private StatsUI _statsUI;
    [SerializeField] private CharacterChoiceUI _characterChoice;

    private GameObject _currentCharacter;
    private int _currentId = 0;
    private Coroutine _coroutine;

    public GameObject CurrentCharacter => _currentCharacter;

    private void Start()
    {
        float delay = 0.5f;
        _coroutine = StartCoroutine(Delay(delay));
        _charactersItemUI.UpdateAllButtons(_characterChoice.GetCharacter(_currentId));
        ShowStats();
        _statsUI.UpdateName(_characterChoice.GetCharacter(_currentId).GetComponent<CharacterStats>().Name);
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

        if (_currentId == _characterChoice.AllCharacters)
        {
            _currentId = 0;
            _characterChoice.ChoisedCharacter(_currentId, _characterChoice.AllCharacters - 1);
        }
        else if (_currentId < 0)
        {
            _currentId = _characterChoice.AllCharacters - 1;
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
        _characterChoice.GetCharacter(_currentId).GetComponent<CharacterItems>().ChangeItem(type, isWear, item, isHand);
        ShowStats();
        ShowCharacter();
    }

    private void SetCharacter()
    {
        _charactersItemUI.UpdateAllButtons(_characterChoice.GetCharacter(_currentId));
        ShowStats();
        _statsUI.UpdateName(_characterChoice.GetCharacter(_currentId).GetComponent<CharacterStats>().Name);

        _foldingScreen.SetActive(false);
        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(Delay(0));
    }

    private void ShowStats()
    {
        CharacterStats characterStats = _characterChoice.GetCharacter(_currentId).GetComponent<CharacterStats>();
        _statsUI.UpdateAllStats(characterStats.Attack, characterStats.Defense, characterStats.Health);
    }

    private void ShowCharacter()
    {
        Destroy(_currentCharacter);
        _currentCharacter = Instantiate(_characterChoice.GetCharacter(_currentId), _pointToCreate) as GameObject;
        _currentCharacter.GetComponent<StateMachine>().enabled = false;
        _currentCharacter.transform.position = _pointToCreate.position;
        _currentCharacter.transform.localScale = new Vector3(80f, 80f, 1);
    }

    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);

        _foldingScreen.SetActive(true);
        float delayScreen = 0.25f;
        yield return new WaitForSeconds(delayScreen);

        ShowCharacter();
    }
}
