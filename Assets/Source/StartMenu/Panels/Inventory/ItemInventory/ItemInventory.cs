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

    public void Assign—haracteristics(Sprite image, ItemType type)
    {
        Image = image;
        _itemObject.transform.GetChild(0).GetComponent<Image>().sprite = Image;

        Type = type;
    }

    public void UpdateInformation(int id, Sprite image,ItemType type)
    {
        AssignId(id);
        Assign—haracteristics(image, type);
    }
}
