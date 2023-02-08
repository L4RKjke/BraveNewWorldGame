using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TavernUI : RenderUI
{
    [SerializeField] private List<GameObject> _characters;
    [SerializeField] private List<HeroNamesCreater> _heroNamesCreater;
    [SerializeField] private List<HeroStatsCreater> _heroStatsCreater;
    [SerializeField] private List<HeroAppearanceCreater> _heroAppearanceCreater;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private CharactersStorage _charactersStorage;
    [SerializeField] private GameObject _disclaimer;
    [SerializeField] private GameObject _characterChangeUI;
    [SerializeField] private ButtonUpdate _buttonUpdate;
    [SerializeField] private TavernSaveLoad _tavernSaveLoad;

    private int _priceUpdate = 500;

    public Transform ContainerTransform => Container.transform;

    private void Awake()
    {
        _buttonUpdate.Button.onClick.AddListener(delegate { UpdateTavern(); });
        _buttonUpdate.Init(_priceUpdate, _wallet);

        if (Container.transform.childCount == 0)
            AddGraphics();
    }

    private void OnDisable()
    {
        _disclaimer.SetActive(false);
    }

    protected override void AddGraphics()
    {
        for (int i = 0; i < _characters.Count; i++)
        {
            AddButton(i);
        }
    }

    public GameObject AddButton(int id)
    {
        GameObject newButton = Instantiate(Content, Container.transform) as GameObject;
        newButton.name = (Container.transform.childCount - 1).ToString();
        GameObject newCharacter = newButton.GetComponentInChildren<TavernCharactersUI>().ShowCharacter(_characters[id]);
        CharacterStats characterStats = newCharacter.GetComponent<CharacterStats>();
        _heroStatsCreater[id].CreateStats(characterStats);
        _heroNamesCreater[id].SetName(characterStats);
        StatsUI statsUI = newButton.GetComponentInChildren<StatsUI>();
        statsUI.Init();
        statsUI.UpdateName(characterStats.Name);
        statsUI.UpdateAllStats(characterStats.Attack, characterStats.Defense, characterStats.Health, characterStats.Magic);

        CharacterData characterData = new CharacterData();
        _heroAppearanceCreater[id].CreateAppereance(newCharacter.GetComponent<Appearance>(), characterData);
        characterData.SetStats(characterStats.Name, characterStats.Attack, characterStats.Defense, characterStats.Health, characterStats.Magic);
        characterData.SetClass(id);
        _tavernSaveLoad.AddData(characterData);

        Button temp = newButton.GetComponentInChildren<Button>();
        temp.onClick.AddListener(delegate { TrySellCharacter(newButton, characterData); });
        temp.transform.GetChild(temp.transform.childCount - 1).gameObject.SetActive(true);

        return newButton;
    }

    private void UpdateTavern()
    {
        bool canUpdate = _buttonUpdate.CheckCanUpdate();

        if (canUpdate)
        {
            _wallet.ChangeGold(-_priceUpdate);
            DeleteAllButtons();
            _tavernSaveLoad.ClearData();
            AddGraphics();
        }
    }

    private void TrySellCharacter(GameObject button, CharacterData characterData)
    {
        GameObject character = button.GetComponentInChildren<TavernCharactersUI>().GetCharacter();

        int heroPrice = 500;

        if (_charactersStorage.IsFree)
        {
            if (_wallet.Gold >= heroPrice)
            {
                _wallet.ChangeGold(-heroPrice);

                _charactersStorage.AddNewCharacter(character);
                _charactersStorage.CharactersSaveLoad.AddData(characterData);

                Button temp = button.GetComponentInChildren<Button>();
                temp.interactable = false;
                temp.GetComponentInChildren<TMP_Text>().text = "Sold";
                button.transform.GetChild(button.transform.childCount - 1).gameObject.SetActive(true);
            }
            else
            {
                string notMoney = "Not enough money";

                DisclaimerOn(button, notMoney);
            }
        }
        else
        {
            _characterChangeUI.SetActive(true);

            _characterChangeUI.GetComponent<CharacterChangeUI>().Init(_charactersStorage, button);
        }
    }

    private void DisclaimerOn(GameObject button, string text)
    {
        _disclaimer.SetActive(false);
        _disclaimer.GetComponentInChildren<TMP_Text>().text = text;
        _disclaimer.transform.position = button.transform.position;
        _disclaimer.SetActive(true);
    }
}
