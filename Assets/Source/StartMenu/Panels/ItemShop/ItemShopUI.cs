using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ItemStorage))]
public class ItemShopUI : RenderUI
{
    [SerializeField] private PlayerItemStorage _playerItemStorage;

    private ItemStorage _itemStorage;

    private void Awake()
    {
        _itemStorage = GetComponent<ItemStorage>();
        AddGraphics();
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
        GameObject newItemButton = Instantiate(Ñontainer, Content.transform) as GameObject;
        newItemButton.name = Content.transform.childCount.ToString();
        StatsUI statsUI = newItemButton.GetComponent<StatsUI>();
        newItemButton.GetComponentInChildren<TMP_Text>().text = item.Name;
        newItemButton.GetComponentInChildren<Image>().sprite = item.Image;
        statsUI.UpdateAllStats(item.Attack, item.Defense, item.Health);
        newItemButton.GetComponentInChildren<Button>().onClick.AddListener(delegate { SellItem(item, newItemButton); });
    }

    private void SellItem(Item item, GameObject button)
    {
        item.SetId(_playerItemStorage.CountItems);
        _playerItemStorage.AddItem(item);
        button.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        button.transform.GetChild(button.transform.childCount - 1).gameObject.SetActive(true);
    }
}
