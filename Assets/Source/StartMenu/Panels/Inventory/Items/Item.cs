using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private string _type;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;
    [SerializeField] private int _defense;
    [SerializeField] private int _attack;
    [SerializeField] private int _health;

    public int Id => _id;
    public Sprite Image => _image;
    public string Name => _name;
    public string Type => _type;
}
