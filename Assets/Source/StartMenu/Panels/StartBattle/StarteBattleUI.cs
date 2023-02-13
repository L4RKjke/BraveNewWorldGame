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
    [SerializeField] private CharactersArena _charactersArena;

    private List<int> _charactersId = new List<int>();
    private int _maxSizeParty = 5;
    private Vector3 _offSet = new(0, -2f, 0);

    public CharactersArena CharactersArena => _charactersArena; 

    private void Awake()
    {
        _charactersAddBattle.Init(_charactersStorage, this);
        AddGraphics();
        _charactersAddBattle.enabled = true;
    }

    private void OnEnable()
    {
        _charactersArena.ArenaCells.ResetLastParty();
    }

    private void OnDisable()
    {
        ReturnAllCharacters();
        _disclaimer.SetActive(false);
    }

    public void TryAddCharacter(GameObject character, Button button, int characterID)
    {
        for (int i = 0; i < Container.transform.childCount; i++)
        {
            if (Container.transform.GetChild(i).childCount == 0)
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

    public void TryToStartPhase2(CameraChanger cameraChanger)
    {
        if (_charactersId.Count > 0)
        {
            cameraChanger.ReturnToPrevios();

            for (int i = 0; i < _charactersId.Count; i++)
            {
                _charactersArena.AddLastCharacterID(_charactersId[i]);
            }

            ReturnAllCharacters();
            _charactersArena.AddCharacters();
            this.gameObject.SetActive(false);

            //_arenaCells.BuildBanMesh(); //??
        }
    }

    protected override void AddGraphics()
    {
        for(int i = 0; i < _maxSizeParty; i++)
        {
            GameObject newContent = Instantiate(Content, Container.transform);
            newContent.name = i.ToString();
        }
    }

    private void AddCharacter(GameObject character, int buttonID, int characterID)
    {
        _charactersId.Add(characterID);
        GameObject content = Container.transform.GetChild(buttonID).gameObject;
        character.SetActive(true);
        character.transform.SetParent(content.transform);
        character.transform.localScale = new Vector3(120f, 120f, 1);
        character.transform.position = content.transform.position + _offSet;
        Button button = content.GetComponent<Button>();
        button.onClick.AddListener(delegate { ReturnCharacter(buttonID, characterID); });
    }

    private void ReturnCharacter(int buttonID, int characterID)
    {
        _charactersStorage.ReturnCharacter(characterID);
        _charactersId.Remove(characterID);
        Container.transform.GetChild(buttonID).GetComponent<Button>().onClick.RemoveAllListeners();
        _charactersAddBattle.ReturnListener(characterID, _characterOffOn[0]);
    }

    private void ReturnAllCharacters()
    {
        for (int i = 0; i < Container.transform.childCount; i++)
        {
            if (Container.transform.GetChild(i).childCount != 0)
                Container.transform.GetChild(i).GetComponent<Button>().onClick.Invoke();
        }
    }
}
