using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryStorage : MonoBehaviour
{
    private List<ItemInventory> _cells = new List<ItemInventory>();

    private int _itemsCount = 0;

    public int InventorySize => _cells.Count;
    public int ItemsCount => _itemsCount;

    public ItemInventory GetItem(int id)
    {
        return _cells[id];
    }

    public void AddItem(int id, Item item)
    {
        _cells[id].UpdateInformation(item.Id, item.Image, item.Name, item.Type);
    }

    public int FindEmptySlots()
    {
        for(int i = 0; i < _cells.Count; i++)
        {
            if (_cells[i].Id == 0)
                return i;
        }

        return -1;
    }

    public void CreateInventory(int count, Item item)
    {
        for(int i = 0; i < count; i++)
        {
            AddItem(i, item);
        }
    }

    public void AddSlot(ItemInventory slot)
    {
        _cells.Add(slot);
    }

    public void SortingInventory(int startId, PlayerItemStorage itemStorage)
    {
        for (int i = startId; i < InventorySize; i++)
        {
            if (i < InventorySize - 1)
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
        int lastId = _cells[0].Id;
        int countSortingBreak = 0;

        for (int i = 0; i < _cells.Count; i++)
        {

            if (_cells[i].Id == 0 && lastId != _cells[i].Id)
            {
                countSortingBreak++;

                if (countSortingBreak == 2)
                {
                    needSorting = false;
                    break;
                }
            }

            lastId = _cells[i].Id;
        }

        return needSorting;
    }
}
