using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InventoryUI))]
public class PlayerItemStorage : MonoBehaviour
{
    [SerializeField] private List<Item> _items = new List<Item>();
    [SerializeField] private Transform _itemsFolder;

    private InventoryUI _inventoryUI;

    public int CountItems => _items.Count;
    public int MaxSizeInventory => _inventoryUI.MaxCount;

    private void Awake()
    {
        _inventoryUI = GetComponent<InventoryUI>();
    }

    public void DeleteItem(int id)
    {
        Destroy(_items[id].gameObject);
    }

    public Item GetItem(int id)
    {
        return _items[id];
    }

    public void AddItem(Item item)
    {
        item.transform.parent = _itemsFolder;
        _items.Add(item);
        ReturnItem(item);
    }

    public void ReturnItem(Item item)
    {
        _inventoryUI.ReturnItem(item);
    }

    public void ChangeItem(Item item, int id)
    {
        item.transform.parent = _itemsFolder;
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
