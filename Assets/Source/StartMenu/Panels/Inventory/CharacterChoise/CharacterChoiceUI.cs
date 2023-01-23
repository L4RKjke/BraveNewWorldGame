using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChoiceUI : RenderUI
{
    [SerializeField] private List<GameObject> _characters;
    [SerializeField] private CharacterPlayerUI _characterPlayerUI;

    public int AllCharacters => _characters.Count;

    private void Start()
    {
        AddGraphics();
    }

    public GameObject GetCharacter(int id)
    {
        return _characters[id];
    }

    protected override void AddGraphics()
    {
        for (int i = 0; i < AllCharacters; i++)
        {
            GameObject newButton = Instantiate(Ñontainer, Content.transform) as GameObject;
            newButton.name = i.ToString();
            UpdateButtonGraphics(newButton, _characters[i]);

            if (_characterPlayerUI.CurrentCharacter == _characters[i])
            {
                ChoisedCharacter(i);
            }    
        }

        if (_characterPlayerUI.CurrentCharacter == null)
        {
            ChoisedCharacter(0);
        }
    }

    public void ChoisedCharacter(int currentId, int previosId = -1)
    {
        GameObject button = Content.transform.GetChild(currentId).gameObject;
        button.transform.GetChild(1).GetComponent<Image>().enabled = true;
        Button tempButton = button.GetComponent<Button>();
        tempButton.onClick.RemoveAllListeners();

        if (previosId != -1)
        {
            GameObject button2 = Content.transform.GetChild(previosId).gameObject;
            button2.transform.GetChild(1).GetComponent<Image>().enabled = false;
            AddListenerButton(button2);
        }
    }

    private void UpdateButtonGraphics(GameObject button, GameObject character)
    {
        UpdateCharactersIcon(button.transform.GetChild(0).gameObject, character.GetComponent<ItemRender>().Head);
        button.GetComponentInChildren<TMP_Text>().text = character.GetComponent<CharacterStats>().Name;

        AddListenerButton(button);
    }

    private void UpdateCharactersIcon(GameObject buttonHead, GameObject head)
    {
        for(int i = 0; i < head.transform.childCount; i++)
        {
            if (buttonHead.transform.GetChild(i).GetComponent<Image>() != null)
            {
                AddSprite(buttonHead, head, i);

                for (int k = 0; k < head.transform.GetChild(i).transform.childCount; k++)
                {
                    AddSprite(buttonHead.transform.GetChild(i).gameObject, head.transform.GetChild(i).gameObject, k);
                    Debug.Log(buttonHead.transform.GetChild(i).gameObject);
                }
            }
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
    }

    private void AddListenerButton(GameObject button)
    {
        Button tempButton = button.GetComponent<Button>();
        tempButton.onClick.AddListener(delegate { _characterPlayerUI.SetCurrentCharacter(int.Parse(button.name)); });
    }
}
