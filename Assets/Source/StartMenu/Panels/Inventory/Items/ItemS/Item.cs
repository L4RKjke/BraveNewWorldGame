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
    [SerializeField] ItemType ItemType;

    private int _id = 0;

    public int Id => _id;
    public Sprite Image => _image;
    public string Name => _name;
    public ItemType Type => ItemType;
    public int Defense => _defense;
    public int Attack => _attack;
    public int Health => _health;

    public void SetId(int id)
    {
        _id = id;
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
