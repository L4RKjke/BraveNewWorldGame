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
            GameObject newButton = Instantiate(Ñontainer, Content.transform) as GameObject;
            newButton.name = i.ToString();
            UpdateButtonGraphics(newButton, CharactersStorage.GetCharacter(i), i);
        }
    }

    protected void UpdateButtonGraphics(GameObject button, GameObject character, int id = 0)
    {
        UpdateCharactersIcon(button.transform.GetChild(0).gameObject, character.GetComponent<ItemRender>().Head);
        button.GetComponentInChildren<TMP_Text>().text = character.GetComponent<CharacterStats>().Name;

        AddListenerButton(button, id);
    }

    protected abstract void AddListenerButton(GameObject button, int id = 0);

    private void UpdateCharactersIcon(GameObject buttonHead, GameObject head, int id = 0)
    {
        AddSprite(buttonHead, head, 0);

        for (int i = 0; i < head.transform.GetChild(id).childCount; i++)
        {
            AddSprite(buttonHead.transform.GetChild(id).gameObject, head.transform.GetChild(id).gameObject, i);
            UpdateCharactersIcon(buttonHead.transform.GetChild(id).gameObject, head.transform.GetChild(id).gameObject, i);
        }
    }

    private void AddSprite(GameObject objectIMG, GameObject objectSprite, int id)
    {
        objectIMG.transform.GetChild(id).TryGetComponent(out Image tempIMG);
        objectSprite.transform.GetChild(id).TryGetComponent(out SpriteRenderer tempSprite);
        tempIMG.sprite = tempSprite.sprite;
        tempIMG.color = tempSprite.color;

        if (objectSprite.transform.GetChild(id).GetComponent<SpriteRenderer>().sprite == null)
            tempIMG.color = new Color(tempIMG.color.r, tempIMG.color.g, tempIMG.color.b, 0);

        tempIMG.enabled = tempSprite.enabled;
    }
}
