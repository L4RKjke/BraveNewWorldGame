using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSaveLoad : MonoBehaviour, BinarrySaves
{
    [SerializeField] private ItemShopUI _itemShop;
    [SerializeField] private ItemStorage _itemStorage;
    [SerializeField] private PlayerItemStorage _playerItemStorage;

    public void Load(ShopData shopData)
    {
        Item item = null;

        for (int i = 0; i < shopData.IsSold.Length; i++)
        {
            if(shopData.IsSold[i] == false)
            {
                Enum.TryParse(shopData.Type[i], out ItemType result);

                switch (result)
                {
                    case ItemType.Weapon:
                        item = Instantiate(_itemStorage.GetWeapon(shopData.ItemSearchID[i]));
                        break;
                    case ItemType.Hand:
                        item = Instantiate(_itemStorage.GetHand(shopData.ItemSearchID[i]));
                        break;
                    case ItemType.Head:
                        item = Instantiate(_itemStorage.GetHead(shopData.ItemSearchID[i]));
                        break;
                    case ItemType.Body:
                        item = Instantiate(_itemStorage.GetBody(shopData.ItemSearchID[i]));
                        break;
                    case ItemType.Leg:
                        item = Instantiate(_itemStorage.GetLeg(shopData.ItemSearchID[i]));
                        break;
                }

                _itemShop.AddButton(item);
                item.SetSearchID(shopData.ItemSearchID[i]);
            }
            else
            {
                item = Instantiate(_playerItemStorage.GetItem(0));
                GameObject button = _itemShop.AddButton(item);
                Button temp = button.GetComponentInChildren<Button>();
                temp.interactable = false;
                button.GetComponentInChildren<TMP_Text>().text = Lean.Localization.LeanLocalization.GetTranslationText("Common/Sold");
                temp.gameObject.transform.GetComponentInChildren<TMP_Text>().text = Lean.Localization.LeanLocalization.GetTranslationText("Common/Sold");
                button.transform.GetChild(button.transform.childCount - 2).gameObject.SetActive(true);
            }
        }
    }

    public void Save()
    {
        BinarySavingSystem.SaveShop(_itemShop);
    }

    public ShopData GetData()
    {
        ShopData shopData = new ShopData(_itemShop);
        return shopData;
    }
}
