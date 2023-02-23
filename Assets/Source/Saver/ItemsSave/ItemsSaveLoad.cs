using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSaveLoad : MonoBehaviour, BinarrySaveLoad
{
    [SerializeField] private ItemStorage _itemStorage;
    [SerializeField] private PlayerItemStorage _playerItemStorage;

    public void Load()
    {
        ItemData items = BinarySavingSystem.LoadItems();
        Item newItem = null;

        for (int i = 0; i < items.SearchID.Length; i++)
        {
            if (items.SearchID[i] != -1)
            {

                Enum.TryParse(items.Type[i], out ItemType result);

                switch (result)
                {
                    case ItemType.Weapon:
                        newItem = Instantiate(_itemStorage.GetWeapon(items.SearchID[i]));
                        break;
                    case ItemType.Hand:
                        newItem = Instantiate(_itemStorage.GetHand(items.SearchID[i]));
                        break;
                    case ItemType.Head:
                        newItem = Instantiate(_itemStorage.GetHead(items.SearchID[i]));
                        break;
                    case ItemType.Body:
                        newItem = Instantiate(_itemStorage.GetBody(items.SearchID[i]));
                        break;
                    case ItemType.Leg:
                        newItem = Instantiate(_itemStorage.GetLeg(items.SearchID[i]));
                        break;
                }

                newItem.SetLevel(items.Level[i]);
                newItem.SetSearchID(items.SearchID[i]);
                newItem.SetId(i + 1);
            }
            else
            {
                newItem = null;
                _playerItemStorage.AddNullSlot();
            }

            _playerItemStorage.AddItem(newItem);
        }
    }

    public void Save()
    {
        BinarySavingSystem.SaveItem(_playerItemStorage);
    }
}
