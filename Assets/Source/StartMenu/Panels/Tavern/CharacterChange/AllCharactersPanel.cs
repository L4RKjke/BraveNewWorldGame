using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AllCharactersPanel : RenderUI
{
    protected CharactersStorage CharactersStorage;

    protected override void AddGraphics()
    {
        for (int i = 0; i < CharactersStorage.AllCharacters; i++)
        {
            GameObject newButton = Instantiate(Content, Container.transform) as GameObject;
            newButton.name = i.ToString();
            UpdateButtonGraphics(newButton, CharactersStorage.GetCharacter(i), i);
        }
    }

    protected void UpdateButtonGraphics(GameObject button, GameObject character, int id = 0)
    {
        CharacterHeadButton temp = button.GetComponent<CharacterHeadButton>();

        temp.SetHead(character.GetComponent<ItemRender>().Head);
        temp.SetNameAndLevel(character.GetComponent<CharacterStats>().Name, character.GetComponent<CharacterStats>().Level);
        AddListenerButton(button, id);
    }

    protected abstract void AddListenerButton(GameObject button, int id = 0);
}
