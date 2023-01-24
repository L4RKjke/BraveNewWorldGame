using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;
    [SerializeField] private int _defense;
    [SerializeField] private int _attack;
    [SerializeField] private int _health;
    [SerializeField] private int _magic;
    [SerializeField] ItemType ItemType;

    private int _id = 0;
    private int _price;

    public int Id => _id;
    public Sprite Image => _image;
    public string Name => _name;
    public ItemType Type => ItemType;
    public int Defense => _defense;
    public int Attack => _attack;
    public int Health => _health;
    public int Magic => _magic;
    public int Price => _price;

    public void SetId(int id)
    {
        _id = id;
    }

    public void SetPrice()
    {
        if (ItemType == ItemType.Weapon)
            _price = 250;
        else if (ItemType == ItemType.Hand)
            _price = 200;
        else if (ItemType == ItemType.Head)
            _price = 100;
        else if (ItemType == ItemType.Body)
            _price = 175;
        else if (ItemType == ItemType.Leg)
            _price = 150;
    }
}

public enum ItemType
{
    Weapon,
    Hand,
    Head,
    Leg,
    Body
}
