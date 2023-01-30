using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private string _name = "AnimeTester";
    private int _attack = 0;
    private int _defense = 0;
    private int _health = 1;
    private int _magic = 0;

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

    public void SetName(string name)
    {
        _name = name;
    }
}
