using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(InventoryUI))]
public class PlayerItemStorage : MonoBehaviour
{
    [SerializeField] private List<Item> _items = new List<Item>();
    [SerializeField] private Transform _itemsFolder;

    private InventoryUI _inventoryUI;
    private int _nullSlots = 0;

    public event UnityAction ItemCountChange;
    public int CountItems => _items.Count;
    public int MaxSizeInventory => _inventoryUI.MaxCount;
    public int NullSlots => _nullSlots;

    private void Awake()
    {
        _inventoryUI = GetComponent<InventoryUI>();
    }

    public void DeleteItem(int id)
    {
        Destroy(_items[id].gameObject);
        _nullSlots++;
        ItemCountChange?.Invoke();
    }

    public Item GetItem(int id)
    {
        return _items[id];
    }

    public bool TryAddItem(Item item)
    {
        bool isSucces = false;

        if (MaxSizeInventory > CountItems - 1 - NullSlots)
        {
            int id = GetFreeId();
            item.SetId(id);
            Debug.Log(id);

            if (id == CountItems)
            {
                AddItem(item);
            }
            else
            {
                ChangeItem(item, id);
            }

            ItemCountChange?.Invoke();
            ReturnItem(item);
            isSucces = true;
        }

        return isSucces;
    }

    public void ReturnItem(Item item)
    {
        _inventoryUI.ReturnItem(item);
    }

    public void AddItem(Item item)
    {
        if(item != null)
        item.transform.parent = _itemsFolder;

        _items.Add(item);
    }

    private void ChangeItem(Item item, int id)
    {
        item.transform.parent = _itemsFolder;
        _items[id] = item;
        ItemCountChange?.Invoke();
    }

    private int GetFreeId()
    {
        for(int i = 1; i < _items.Count; i++)
        {
            if (_items[i] == null)
            {
                _nullSlots--;
                return i;
            }
        }
        return _items.Count;
    }
}
