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

    private ItemStorage _itemStorage;

    private void Awake()
    {
        _itemStorage = GetComponent<ItemStorage>();
    }

    private void OnEnable()
    {
        _disclaimer.SetActive(false);
        AddGraphics();
    }

    private void OnDisable()
    {
        DeleteAllButtons();
    }

    protected override void AddGraphics()
    {
        Item item = _itemStorage.GetHead(Random.Range(0,_itemStorage.HeadCount));
        AddButton(item);
        item = _itemStorage.GetBody(Random.Range(0,_itemStorage.BodyCount));
        AddButton(item);
        item = _itemStorage.GetLeg(Random.Range(0, _itemStorage.LegCount));
        AddButton(item);
        item = _itemStorage.GetHand(Random.Range(0, _itemStorage.HandCount));
        AddButton(item);
        item = _itemStorage.GetWeapon(Random.Range(0, _itemStorage.WeaponCount));
        AddButton(item);
    }

    private void AddButton(Item item)
    {
        GameObject newItemButton = Instantiate(Content, Container.transform) as GameObject;
        newItemButton.name = (Container.transform.childCount - 1).ToString();
        StatsUI statsUI = newItemButton.GetComponent<StatsUI>();
        newItemButton.GetComponentInChildren<TMP_Text>().text = item.Name;
        newItemButton.GetComponentInChildren<Image>().sprite = item.Image;
        statsUI.UpdateAllStats(item.Attack, item.Defense, item.Health, item.Magic);
        item.SetPrice();

        Button temp = newItemButton.GetComponentInChildren<Button>();
        temp.onClick.AddListener(delegate { SellItem(item, newItemButton); });
        temp.gameObject.transform.GetComponentInChildren<TMP_Text>().text = item.Price.ToString();
    }

    private void SellItem(Item item, GameObject button)
    {
        if (_playerItemStorage.MaxSizeInventory > _playerItemStorage.CountItems - 1)
        {
            if (_wallet.Gold >= item.Price)
            {
                _wallet.ChangeGold(-item.Price);

                int id = _playerItemStorage.CountItems;
                item.SetId(id);

                if (id == _playerItemStorage.CountItems)
                    _playerItemStorage.AddItem(item);
                else
                    _playerItemStorage.ChangeItem(item, id);

                Button temp = button.GetComponentInChildren<Button>();
                temp.interactable = false;
                temp.gameObject.transform.GetComponentInChildren<TMP_Text>().text = "Sold";
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
            string full = "Inventory FULL";

            DisclaimerOn(button, full);
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
