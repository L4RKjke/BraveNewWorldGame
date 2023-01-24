using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChoiceUI : RenderUI
{
    [SerializeField] private List<GameObject> _temp;
    [SerializeField] private CharacterPlayerUI _characterPlayerUI;
    [SerializeField] private Sprite _choised;

    private List<GameObject> _characters = new List<GameObject>();

    public int AllCharacters => _characters.Count;

    private void Awake()
    {
        for(int i = 0; i < _temp.Count; i++)
        {
            _characters.Add(Instantiate(_temp[i]));
            _characters[i].SetActive(false);
            _characters[i].transform.SetParent(_characterPlayerUI.PointToCreate);
        }
    }

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

    public void UpdateHead(int id)
    {
        UpdateButtonGraphics(Content.transform.GetChild(id).gameObject, _characters[id]);
    }

    public void ChoisedCharacter(int currentId, int previosId = -1)
    {
        GameObject button = Content.transform.GetChild(currentId).gameObject;
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

    private void UpdateButtonGraphics(GameObject button, GameObject character)
    {
        UpdateCharactersIcon(button.transform.GetChild(0).gameObject, character.GetComponent<ItemRender>().Head);
        button.GetComponentInChildren<TMP_Text>().text = character.GetComponent<CharacterStats>().Name;

        AddListenerButton(button);
    }

    private void UpdateCharactersIcon(GameObject buttonHead, GameObject head, int id = 0)
    {
        for(int i = 0; i < head.transform.GetChild(id).childCount; i++)
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

    private void AddListenerButton(GameObject button)
    {
        Button tempButton = button.GetComponent<Button>();
        tempButton.onClick.AddListener(delegate { _characterPlayerUI.SetCurrentCharacter(int.Parse(button.name)); });
    }
}
