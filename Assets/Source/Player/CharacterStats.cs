using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private string _name = "AnimeTester";
    private int _itemAttack = 0;
    private int _itemDefense = 0;
    private int _itemHealth = 0;
    private int _itemMagic = 0;
    private int _baseAttack;
    private int _baseDefense;
    private int _baseHealth;
    private int _baseMagic;

    public string Name => _name;
    public int Attack => _itemAttack + _baseAttack;
    public int Defense => _itemDefense + _baseDefense;
    public int Health => _itemHealth + _baseHealth;
    public int Magic => _itemMagic + _baseMagic;

    public void SetBaseStats(int attack, int defense, int health, int magic, bool isDistribute = false)
    {
        if (isDistribute == false)
        {
            _baseAttack = attack;
            _baseDefense = defense;
            _baseHealth = health;
            _baseMagic = magic;
        }
        else
        {
            _baseAttack += attack;
            _baseDefense += defense;
            _baseHealth += health;
            _baseMagic += magic;
        }
    }

    public void AssignStat(int attack, int defense, int health, int magic)
    {
        _itemAttack += attack;
        _itemDefense += defense;
        _itemHealth += health;
        _itemMagic += magic;
    }

    public void SetName(string name)
    {
        _name = name;
    }
}
