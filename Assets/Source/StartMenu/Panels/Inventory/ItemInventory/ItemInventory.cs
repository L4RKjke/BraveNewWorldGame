using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemInventory
{
    private int _id;
    private GameObject _itemObject;

    public GameObject ItemObject => _itemObject;
    public Sprite Image { get; private set; }
    public string Name { get; private set; }
    public ItemType Type { get; private set; }
    public int Id => _id;


    public void AssignGameObject(GameObject item)
    {
        _itemObject = item;
    }

    public void AssignId(int id)
    {
        _id = id;
    }

    public void Assign—haracteristics(string name, Sprite image, ItemType type)
    {
        Name = name;
        _itemObject.GetComponentInChildren<TMP_Text>().text = Name;

        Image = image;
        _itemObject.transform.GetChild(0).GetComponent<Image>().sprite = Image;

        Type = type;
    }

    public void UpdateInformation(int id, Sprite image, string name, ItemType type)
    {
        AssignId(id);
        Assign—haracteristics(name, image, type);
    }
}
