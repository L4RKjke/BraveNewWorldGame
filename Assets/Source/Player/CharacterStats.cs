using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : Stats
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
    private int _expiriance = 0;

    public int ExpPerLevel { get; private set; } = 1000;
    public int Exp => _expiriance;
    public int Level => _expiriance / ExpPerLevel + 1;
    public string Name => _name;
    public int Attack => _itemAttack + GetBaseStat(_baseAttack, Level);
    public int Defense => _itemDefense + GetBaseStat(_baseDefense, Level);
    public int Health => _itemHealth + GetBaseStat(_baseHealth, Level);
    public int Magic => _itemMagic + GetBaseStat(_baseMagic, Level);

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

    public void GetExpirience(int expirience, int levelMonsters)
    {
        float levelDifference = levelMonsters - Level;
        float percentLevelDifference = 0;

        if (levelDifference > 0)
        {
            percentLevelDifference = levelDifference / 100 + Level;
        }
        else if (levelDifference < 0)
        {
            percentLevelDifference = levelDifference / 30;
            percentLevelDifference = Mathf.Clamp(percentLevelDifference, -1,0);
        }

        float tempExp = expirience * (1 + percentLevelDifference);
        expirience = (int)tempExp;
        _expiriance += expirience;
    }
}
