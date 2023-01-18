using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStorage : MonoBehaviour
{
    [SerializeField] private List<Item> _items = new List<Item>();

    public int CountItems => _items.Count;

    public Item GetItem(int id)
    {
        return _items[id];
    }
}
