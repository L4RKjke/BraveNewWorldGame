using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersAddBattle : AllCharactersPanel
{
    private StarteBattleUI _starteBattleUI;

    private void OnEnable()
    {
        AddGraphics();
        CheckCharactersAdded();
    }

    private void OnDisable()
    {
        DeleteAllButtons();
    }

    public void Init(CharactersStorage charactersStorage, StarteBattleUI starteBattleUI)
    {
        CharactersStorage = charactersStorage;
        _starteBattleUI = starteBattleUI;
    }

    public void ReturnListener(int buttonId, Sprite spriteOff)
    {
        GameObject button = Container.transform.GetChild(buttonId).gameObject;
        button.GetComponent<CharacterHeadButton>().ChoisedChange(false);
        button.GetComponent<Image>().sprite = spriteOff;
        AddListenerButton(button, buttonId);
    }

    protected override void AddListenerButton(GameObject content, int id = 0)
    {
        Button button = content.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { _starteBattleUI.TryAddCharacter(CharactersStorage.GetCharacter(id), button, id); });
    }

    private void CheckCharactersAdded()
    {
        for (int i = 0; i < Container.transform.childCount; i++)
        {
            if (_starteBattleUI.ArenaCells.CheckId(i))
            {
                Container.transform.GetChild(i).GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}
