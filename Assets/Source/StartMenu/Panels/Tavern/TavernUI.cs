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

    private void OnEnable()
    {
        AddGraphics();
    }

    private void OnDisable()
    {
        DeleteAllButtons();
    }

    protected override void AddGraphics()
    {
        for (int i = 0; i < _characters.Count; i++)
        {
            AddButton(i);
        }
    }

    private void AddButton(int id)
    {
        GameObject newSaler = Instantiate(Ñontainer, Content.transform) as GameObject;
        newSaler.name = (Content.transform.childCount - 1).ToString();
        CharacterStats characterStats = newSaler.GetComponentInChildren<TavernCharactersUI>().ShowCharacter(_characters[id], _heroAppearanceCreater[id]);
        _heroStatsCreater[id].CreateStats(characterStats);
        _heroNamesCreater[id].SetName(characterStats);
        StatsUI statsUI = newSaler.GetComponentInChildren<StatsUI>();
        statsUI.UpdateName(characterStats.Name);
        statsUI.UpdateAllStats(characterStats.Attack, characterStats.Defense, characterStats.Health, characterStats.Magic);

        Button temp = newSaler.GetComponentInChildren<Button>();
        temp.onClick.AddListener(delegate { TrySellCharacter(newSaler); });
    }

    private void TrySellCharacter(GameObject button)
    {
        GameObject character = button.GetComponentInChildren<TavernCharactersUI>().GetCharacter();

        int heroPrice = 500;

        if (_charactersStorage.IsFree)
        {
            if (_wallet.Gold >= heroPrice)
            {
                _wallet.ChangeGold(-heroPrice);

                _charactersStorage.AddNewCharacter(character);

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
