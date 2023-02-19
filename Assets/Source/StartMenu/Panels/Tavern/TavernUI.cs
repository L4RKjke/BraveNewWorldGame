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
    [SerializeField] private List<HeroPassiveSkills> _heroPassiveSkills;
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

    public GameObject AddButton(int id, bool isLoad = false)
    {
        GameObject newButton = Instantiate(Content, Container.transform) as GameObject;
        GameObject newCharacter = newButton.GetComponentInChildren<TavernCharactersUI>().ShowCharacter(_characters[id]);
        newButton.name = (Container.transform.childCount - 1).ToString();
        StatsUI statsUI = newButton.GetComponentInChildren<StatsUI>();
        statsUI.Init();

        if (isLoad == false)
        CharacterCreate(newCharacter, newButton, id);

        return newButton;
    }

    public void AddListenerBuy(GameObject button, CharacterData characterData)
    {
        Button temp = button.GetComponentInChildren<Button>();
        temp.onClick.AddListener(delegate { TrySellCharacter(button, characterData); });
        temp.transform.GetChild(temp.transform.childCount - 1).gameObject.SetActive(true);
    }

    private void CharacterCreate(GameObject character, GameObject button, int id)
    {

        CharacterData characterData = new CharacterData();
        CharacterStats characterStats = character.GetComponent<CharacterStats>();

        _heroStatsCreater[id].CreateStats(characterStats);
        _heroNamesCreater[id].SetName(characterStats, characterData);
        _heroAppearanceCreater[id].CreateAppereance(character.GetComponent<Appearance>(), characterData);
        _heroPassiveSkills[id].SetSkills(character.transform.GetChild(1).gameObject.GetComponent<Recruit>(), characterData);

        StatsUI statsUI = button.GetComponentInChildren<StatsUI>();
        statsUI.UpdateName(characterStats.Name);
        statsUI.UpdateAllStats(characterStats.Attack, characterStats.Defense, characterStats.Health, characterStats.Magic);

        AbilitiesUI abilitiesUI = button.GetComponentInChildren<AbilitiesUI>();
        Ability[] abilities = character.transform.GetChild(1).gameObject.GetComponents<Ability>();
        abilitiesUI.Init(abilities.Length);

        for (int i = 0; i < abilities.Length; i++)
        {
            abilitiesUI.UpdateAbility(i, abilities[i]);
        }


        characterData.SetStats(characterStats.Attack, characterStats.Defense, characterStats.Health, characterStats.Magic);
        characterData.SetClass(id);
        _tavernSaveLoad.AddData(characterData);

        AddListenerBuy(button,characterData);
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
                temp.GetComponentInChildren<TMP_Text>().text = Lean.Localization.LeanLocalization.GetTranslationText("Common/Sold");
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
