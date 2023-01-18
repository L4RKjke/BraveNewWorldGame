using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryStorage : MonoBehaviour
{
    private List<ItemInventory> _items = new List<ItemInventory>();

    public int ItemCount => _items.Count;

    public ItemInventory GetItem(int id)
    {
        return _items[id];
    }

    public void AddItem(int id, Item item)
    {
        _items[id].UpdateInformation(item.Id, item.Image, item.Name, item.Type);
    }

    public void AddSlot(ItemInventory slot)
    {
        _items.Add(slot);
    }

    public void SortingInventory(int startId, ItemStorage itemStorage)
    {
        for (int i = startId; i < ItemCount; i++)
        {
            if (i < ItemCount - 1)
            {
                AddItem(i, itemStorage.GetItem(GetItem(i + 1).Id));
            }
            else
            {
                AddItem(i, itemStorage.GetItem(0));
            }
        }
    }

    public bool CheckSorting()
    {
        bool needSorting = true;
        int lastId = _items[0].Id;
        int countSortingBreak = 0;

        for (int i = 0; i < _items.Count; i++)
        {

            if (_items[i].Id == 0 && lastId != _items[i].Id)
            {
                countSortingBreak++;

                if (countSortingBreak == 2)
                {
                    needSorting = false;
                    break;
                }
            }

            lastId = _items[i].Id;
        }

        return needSorting;
    }
}
