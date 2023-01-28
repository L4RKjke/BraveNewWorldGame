using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChoiceUI : AllCharactersPanel
{
    [SerializeField] private CharacterPlayerUI _characterPlayerUI;
    [SerializeField] private Sprite _choised;

    private void OnEnable()
    {
        AddGraphics();
    }

    private void OnDisable()
    {
        DeleteAllButtons();
    }

    public void Init(CharactersStorage charactersStorage)
    {
        CharactersStorage = charactersStorage;
    }

    public void UpdateHead(int id)
    {
        UpdateButtonGraphics(Content.transform.GetChild(id).gameObject, CharactersStorage.GetCharacter(id));
    }

    public void ChoisedCharacter(int currentId, int previosId = -1)
    {
        GameObject button = Content.transform.GetChild(currentId).gameObject;
        CharacterHeadButton temp = button.GetComponent<CharacterHeadButton>();

        temp.ChoisedChange(true);

        Sprite spriteFree = temp.Circle.sprite;
        temp.SetCircle(_choised);

        Button tempButton = button.GetComponent<Button>();
        tempButton.onClick.RemoveAllListeners();

        if (previosId != -1)
        {
            GameObject button2 = Content.transform.GetChild(previosId).gameObject;
            CharacterHeadButton temp2 = button2.GetComponent<CharacterHeadButton>();
            temp2.ChoisedChange(false);
            temp2.SetCircle(spriteFree);
            AddListenerButton(button2);
        }
    }

    protected override void AddGraphics()
    {
        for (int i = 0; i < CharactersStorage.AllCharacters; i++)
        {
            GameObject newButton = Instantiate(Ñontainer, Content.transform) as GameObject;
            newButton.name = i.ToString();
            UpdateButtonGraphics(newButton, CharactersStorage.GetCharacter(i));

            if (_characterPlayerUI.CurrentId == i)
            {
                ChoisedCharacter(i);
            }    
        }
    }

    protected override void AddListenerButton(GameObject button, int id = 0)
    {
        Button tempButton = button.GetComponent<Button>();
        tempButton.onClick.AddListener(delegate { _characterPlayerUI.SetCurrentCharacter(int.Parse(button.name)); });
    }
}
