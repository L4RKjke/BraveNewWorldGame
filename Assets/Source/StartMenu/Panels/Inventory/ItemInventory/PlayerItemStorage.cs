using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InventoryUI))]
public class PlayerItemStorage : MonoBehaviour
{
    [SerializeField] private List<Item> _items = new List<Item>();

    private InventoryUI _inventoryUI;

    public int CountItems => _items.Count;
    public int MaxSizeInventory => _inventoryUI.MaxCount;

    private void Awake()
    {
        _inventoryUI = GetComponent<InventoryUI>();
    }

    public Item GetItem(int id)
    {
        return _items[id];
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
        ReturnItem(item);
    }

    public void ReturnItem(Item item)
    {
        _inventoryUI.ReturnItem(item);
    }

    public void ChangeItem(Item item, int id)
    {
        _items[id] = item;
    }

    public int GetFreeId()
    {
        for(int i = 1; i < _items.Count; i++)
        {
            if (_items[i] == null)
            {
                return i;
            }
        }

        return _items.Count;
    }
}
