using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _attack;
    [SerializeField] private int _defense;
    [SerializeField] private int _health;

    public string Name => _name;
    public int Attack => _attack;
    public int Defense => _defense;
    public int Health => _health;

    public void AssignStat(int attack, int defense, int health)
    {
        _attack += attack;
        _defense += defense;
        _health += health;
    }
}
