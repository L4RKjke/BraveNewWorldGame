using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _attack;
    [SerializeField] private int _defense;
    [SerializeField] private int _health;
    [SerializeField] private int _magic;

    public string Name => _name;
    public int Attack => _attack;
    public int Defense => _defense;
    public int Health => _health;
    public int Magic => _magic;

    public void AssignStat(int attack, int defense, int health, int magic)
    {
        _attack += attack;
        _defense += defense;
        _health += health;
        _magic += magic;
    }
}
