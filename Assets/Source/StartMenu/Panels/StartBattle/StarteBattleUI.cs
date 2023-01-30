using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarteBattleUI : RenderUI
{
    [SerializeField] private GameObject _disclaimer;
    [SerializeField] private CharactersStorage _charactersStorage;
    [SerializeField] private CharactersAddBattle _charactersAddBattle;
    [SerializeField] private Sprite[] _characterOffOn;

    private List<int> _charactersId = new List<int>();
    private int _maxSizeParty = 5;
    private Vector3 _offSet = new(0, -1.5f, 0);

    private void Awake()
    {
        _charactersAddBattle.Init(_charactersStorage, this);
        AddGraphics();
    }

    private void OnDisable()
    {
        ReturnAllCharacters();
        _disclaimer.SetActive(false);
    }

    public void TryAddCharacter(GameObject character, Button button, int characterID)
    {
        for (int i = 0; i < Ñontainer.transform.childCount; i++)
        {
            if (Ñontainer.transform.GetChild(i).childCount == 0)
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(delegate { ReturnCharacter(i, characterID); });
                button.GetComponent<Image>().sprite = _characterOffOn[1];
                button.GetComponent<CharacterHeadButton>().ChoisedChange(true);
                AddCharacter(character, i, characterID);
                return;
            }
        }

        _disclaimer.SetActive(true);
    }

    protected override void AddGraphics()
    {
        for(int i = 0; i < _maxSizeParty; i++)
        {
            GameObject newContent = Instantiate(Content, Ñontainer.transform);
            newContent.name = i.ToString();
        }
    }

    private void AddCharacter(GameObject character, int buttonID, int characterID)
    {
        _charactersId.Add(characterID);
        GameObject content = Ñontainer.transform.GetChild(buttonID).gameObject;
        character.SetActive(true);
        character.transform.SetParent(content.transform);
        character.transform.position = content.transform.position + _offSet;
        Button button = content.GetComponent<Button>();
        button.onClick.AddListener(delegate { ReturnCharacter(buttonID, characterID); });
    }

    private void ReturnCharacter(int buttonID, int characterID)
    {
        _charactersStorage.ReturnCharacter(characterID);
        _charactersId.Remove(characterID);
        Ñontainer.transform.GetChild(buttonID).GetComponent<Button>().onClick.RemoveAllListeners();
        _charactersAddBattle.ReturnListener(characterID, _characterOffOn[0]);
    }

    private void ReturnAllCharacters()
    {
        for (int i = 0; i < Ñontainer.transform.childCount; i++)
        {
            if (Ñontainer.transform.GetChild(i).childCount == 0)
                return;

            Ñontainer.transform.GetChild(i).GetComponent<Button>().onClick.Invoke();
        }
    }
}
