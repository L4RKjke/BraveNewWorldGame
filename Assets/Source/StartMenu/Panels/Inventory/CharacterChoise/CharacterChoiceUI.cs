using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharactersStorage))]
public class CharacterChoiceUI : AllCharactersPanel
{
    [SerializeField] private CharacterPlayerUI _characterPlayerUI;
    [SerializeField] private Sprite _choised;

    public CharactersStorage CharactersStorageMain => CharactersStorage;


    private void Awake()
    {
        CharactersStorage = GetComponent<CharactersStorage>();
    }

    private void OnEnable()
    {
        AddGraphics();
    }

    private void OnDisable()
    {
        DeleteAllButtons();
    }

    public Transform GetParent()
    {
        return _characterPlayerUI.PointToCreate;
    }

    public void UpdateHead(int id)
    {
        UpdateButtonGraphics(Content.transform.GetChild(id).gameObject, CharactersStorage.GetCharacter(id));
    }

    public void ChoisedCharacter(int currentId, int previosId = -1)
    {
        GameObject button = Content.transform.GetChild(currentId).gameObject;
        Debug.Log(button.transform.GetChild(1).GetComponent<Image>().enabled);
        button.transform.GetChild(1).GetComponent<Image>().enabled = true;
        Sprite spriteFree = button.GetComponent<Image>().sprite;
        button.GetComponent<Image>().sprite = _choised;
        Button tempButton = button.GetComponent<Button>();
        tempButton.onClick.RemoveAllListeners();

        if (previosId != -1)
        {
            GameObject button2 = Content.transform.GetChild(previosId).gameObject;
            button2.transform.GetChild(1).GetComponent<Image>().enabled = false;
            button2.GetComponent<Image>().sprite = spriteFree;
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
