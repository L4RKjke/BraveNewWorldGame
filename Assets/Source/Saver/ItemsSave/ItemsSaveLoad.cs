using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSaveLoad : MonoBehaviour, BinarrySaveLoad
{
    [SerializeField] private ItemStorage _itemStorage;
    [SerializeField] private PlayerItemStorage _playerItemStorage;

    private List<ItemData> _itemsData = new List<ItemData>();

    public void AddItem(ItemData item)
    {
        _itemsData.Add(item);
    }

    public void DeleteItemData(int id)
    {
        _itemsData[id] = null;
    }

    public void ChangeItemData(int id, ItemData item)
    {
        _itemsData[id] = item;
    }

    public void Load()
    {
        List<ItemData> items = BinarySavingSystem.LoadItems();
        Item newItem = null;

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null)
            {

                Enum.TryParse(items[i].Type, out ItemType result);

                switch (result)
                {
                    case ItemType.Weapon:
                        newItem = Instantiate(_itemStorage.GetWeapon(items[i].SearchID));
                        break;
                    case ItemType.Hand:
                        newItem = Instantiate(_itemStorage.GetHand(items[i].SearchID));
                        break;
                    case ItemType.Head:
                        newItem = Instantiate(_itemStorage.GetHead(items[i].SearchID));
                        break;
                    case ItemType.Body:
                        newItem = Instantiate(_itemStorage.GetBody(items[i].SearchID));
                        break;
                    case ItemType.Leg:
                        newItem = Instantiate(_itemStorage.GetLeg(items[i].SearchID));
                        break;
                }

                newItem.SetLevel(items[i].Level);
            }
            else
            {
                newItem = null;
            }

            _playerItemStorage.AddItem(newItem);
        }
    }

    public void Save()
    {
        for (int i = 0; i < _itemsData.Count; i++)
        {
            BinarySavingSystem.SaveItem(_itemsData[i], i);
        }
    }
}
