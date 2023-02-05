using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemInventory
{
    private int _id;
    private GameObject _itemObject;
    private Item _item;

    public Item Item => _item;
    public GameObject ItemObject => _itemObject;
    public int Id => _id;


    public void AssignGameObject(GameObject item)
    {
        _itemObject = item;
    }

    public void AssignId(int id)
    {
        _id = id;
    }

    public void Assign—haracteristics(Item item, Color rarityColor)
    {
        _item = item;

        _itemObject.transform.GetChild(0).GetComponent<Image>().sprite = _item.Image;
        GameObject rarity = _itemObject.transform.GetChild(1).gameObject;

        if (_item.Type != ItemType.Null)
        {
            rarity.SetActive(true);
            rarity.GetComponent<ItemRarityShow>().SetRarity(rarityColor);
        }
        else
        {
            rarity.SetActive(false);
        }
    }

    public void UpdateInformation(int id, Item item, Color rarityColor)
    {
        AssignId(id);
        Assign—haracteristics(item, rarityColor);
    }
}
