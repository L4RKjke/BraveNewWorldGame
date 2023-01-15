using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryStorage : MonoBehaviour
{
    private List<Item> _items = new List<Item>();

    public Item GetItem(int id)
    {
        return _items[id];
    }
}
