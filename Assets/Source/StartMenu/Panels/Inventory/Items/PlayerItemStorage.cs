using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemStorage : MonoBehaviour
{
    [SerializeField] private List<Item> _items = new List<Item>();

    public int CountItems => _items.Count;

    public Item GetItem(int id)
    {
        return _items[id];
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }
}
