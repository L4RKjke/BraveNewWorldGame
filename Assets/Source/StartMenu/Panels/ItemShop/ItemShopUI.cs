using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ItemStorage))]
public class ItemShopUI : RenderUI
{
    [SerializeField] private PlayerItemStorage _playerItemStorage;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private GameObject _disclaimer;
    [SerializeField] private ButtonUpdate _buttonUpdate;

    private ItemStorage _itemStorage;
    private int _priceUpdate = 50;

    public GameObject ShopContainer => Container;

    private void Awake()
    {
        _itemStorage = GetComponent<ItemStorage>();
        _buttonUpdate.Button.onClick.AddListener(delegate { UpdateShop(); });
        _buttonUpdate.Init(_priceUpdate, _wallet);

        if (Container.transform.childCount == 0)
            AddGraphics();
    }

    private void OnDisable()
    {
        _disclaimer.SetActive(false);
    }

    public GameObject AddButton(Item item)
    {
        GameObject newItemButton = Instantiate(Content, Container.transform) as GameObject;
        newItemButton.name = (Container.transform.childCount - 1).ToString();
        StatsUI statsUI = newItemButton.GetComponent<StatsUI>();
        newItemButton.GetComponentInChildren<TMP_Text>().text = item.Name;
        newItemButton.GetComponentInChildren<Image>().sprite = item.Image;
        statsUI.Init();
        statsUI.UpdateAllStats(item.Attack, item.Defense, item.Health, item.Magic);
        item.SetPrice();

        Button temp = newItemButton.GetComponentInChildren<Button>();
        temp.onClick.AddListener(delegate { SellItem(item, newItemButton); });
        temp.gameObject.transform.GetComponentInChildren<TMP_Text>().text = item.Price.ToString();
        item.transform.SetParent(newItemButton.transform);

        return newItemButton;
    }

    protected override void AddGraphics()
    {
        int searchID = Random.Range(0, _itemStorage.HeadCount);
        Item item = Instantiate(_itemStorage.GetHead(searchID));
        item.SetSearchID(searchID);
        AddButton(item);
        searchID = Random.Range(0, _itemStorage.BodyCount);
        item = Instantiate(_itemStorage.GetBody(searchID));
        item.SetSearchID(searchID);
        AddButton(item);
        searchID = Random.Range(0, _itemStorage.LegCount);
        item = Instantiate(_itemStorage.GetLeg(searchID));
        item.SetSearchID(searchID);
        AddButton(item);
        searchID = Random.Range(0, _itemStorage.HandCount);
        item = Instantiate(_itemStorage.GetHand(searchID));
        item.SetSearchID(searchID);
        AddButton(item);
        searchID = Random.Range(0, _itemStorage.WeaponCount);
        item = Instantiate(_itemStorage.GetWeapon(searchID));
        item.SetSearchID(searchID);
        AddButton(item);
    }

    private void UpdateShop()
    {
        bool canUpdate = _buttonUpdate.CheckCanUpdate();

        if (canUpdate)
        {
            _wallet.ChangeGold(-_priceUpdate);
            DeleteAllButtons();
            AddGraphics();
        }
    }

    private void SellItem(Item item, GameObject button)
    {
        if (_wallet.Gold >= item.Price)
        {
            bool isAddSucces = _playerItemStorage.TryAddItem(item);

            if (isAddSucces)
            {
                _wallet.ChangeGold(-item.Price);

                Button temp = button.GetComponentInChildren<Button>();
                temp.interactable = false;
                temp.gameObject.transform.GetComponentInChildren<TMP_Text>().text = Lean.Localization.LeanLocalization.GetTranslationText("Common/Sold");
                button.transform.GetChild(button.transform.childCount - 1).gameObject.SetActive(true);
            }
            else
            {
                string full = Lean.Localization.LeanLocalization.GetTranslationText("Refusal/Inventory");

                DisclaimerOn(button, full);
            }
        }
        else
        {
            string notMoney = Lean.Localization.LeanLocalization.GetTranslationText("Refusal/NotMoney");

            DisclaimerOn(button, notMoney);
        }
    }

    private void DisclaimerOn(GameObject button, string text)
    {
        _disclaimer.SetActive(false);
        _disclaimer.GetComponentInChildren<TMP_Text>().text = text;
        _disclaimer.transform.position = button.GetComponentInChildren<Image>().transform.position;
        _disclaimer.SetActive(true);
    }
}
