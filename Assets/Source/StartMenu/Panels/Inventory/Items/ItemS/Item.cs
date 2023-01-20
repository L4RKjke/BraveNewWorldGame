using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;
    [SerializeField] private int _defense;
    [SerializeField] private int _attack;
    [SerializeField] private int _health;
    [SerializeField] ItemType ItemType;

    public int Id => _id;
    public Sprite Image => _image;
    public string Name => _name;
    public ItemType Type => ItemType;
    public int Defense => _defense;
    public int Attack => _attack;
    public int Health => _health;
}

public enum ItemType
{
    Weapon,
    Hand,
    Head,
    Leg,
    Body
}
