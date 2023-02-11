using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfo : Stats
{
    [SerializeField] private int _attack;
    [SerializeField] private int _health;
    [SerializeField] private int _gold;
    [SerializeField] private int _exp;
    [SerializeField] private Sprite _head;
    [SerializeField] private string _name;


    public Sprite Sprite => _head;
    public string Name => _name;
    public int Gold => _gold;
    public int Exp => _exp;
    public int Attack => _attack;
    public int Health => _health;
}
