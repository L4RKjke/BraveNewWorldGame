using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterItems : MonoBehaviour
{
    private Item _head;
    private Item _body;
    private Item _leg;
    private Item _hand;
    private Item _weapon;

    public Item GetItem(string type)
    {
        type = type.ToLower();

        switch (type)
        {
            case "weapon":
                return _weapon;
            case "hand":
                return _hand;
            case "head":
                return _head;
            case "body":
                return _body;
            case "leg":
                return _leg;
        }

        return null;
    }

    public void ChangeItem(string type, bool isWear, Item item = null)
    {
        type = type.ToLower();

        switch (type)
        {
            case "weapon":
                {
                    if (isWear)
                    {
                        _weapon = item;
                        ChangeStats(_weapon, isWear);
                    }
                    else
                    {
                        ChangeStats(_weapon, isWear);
                        _weapon = null;
                    }
                }
                break;
            case "hand":
                {
                    if (isWear)
                    {
                        _hand = item;
                        ChangeStats(_hand, isWear);
                    }
                    else
                    {
                        ChangeStats(_hand, isWear);
                        _hand = null;
                    }
                }
                break;
            case "head":
                {
                    if (isWear)
                    {
                        _head = item;
                        ChangeStats(_head, isWear);
                    }
                    else
                    {
                        ChangeStats(_head, isWear);
                        _head = null;
                    }
                }
                break;
            case "body":
                {
                    if (isWear)
                    {
                        _body = item;
                        ChangeStats(_body, isWear);
                    }
                    else
                    {
                        ChangeStats(_body, isWear);
                        _body = null;
                    }
                }
                break;
            case "leg":
                {
                    if (isWear)
                    {
                        _leg = item;
                        ChangeStats(_leg, isWear);
                    }
                    else
                    {
                        ChangeStats(_leg, isWear);
                        _leg = null;
                    }
                }
                break;
        }
    }

    private void ChangeStats(Item item, bool isWear)
    {
        CharacterStats characterStats = GetComponent<CharacterStats>();

        if (isWear)
            characterStats.AssignStat(item.Attack, item.Defense, item.Health);
        else
            characterStats.AssignStat(-item.Attack, -item.Defense, -item.Health);
    }
}
