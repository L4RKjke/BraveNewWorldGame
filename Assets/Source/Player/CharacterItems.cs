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

    public Item GetItem(ItemType type)
    {
        switch (type)
        {
            case ItemType.Weapon:
                return _weapon;
            case ItemType.Hand:
                return _hand;
            case ItemType.Head:
                return _head;
            case ItemType.Body:
                return _body;
            case ItemType.Leg:
                return _leg;
        }

        return null;
    }

    public void ChangeItem(ItemType type, bool isWear, Item item, bool isHand = false)
    {
       ItemRender itemRender = GetComponent<ItemRender>();
       itemRender.ChangeItem(type, isWear, item, isHand);

        switch (type)
        {
            case ItemType.Weapon:
                {
                    if (isWear)
                    {
                        if(isHand == false)
                        {
                            _weapon = item;
                        }    
                        else
                        {
                            _hand = item;
                        }
                    }
                    else
                    {
                        _weapon = null;
                    }
                }
                break;
            case ItemType.Hand:
                {
                    if (isWear)
                    {
                        _hand = item;
                    }
                    else
                    {
                        _hand = null;
                    }
                }
                break;
            case ItemType.Head:
                {
                    if (isWear)
                    {
                        _head = item;
                    }
                    else
                    {
                        _head = null;
                    }
                }
                break;
            case ItemType.Body:
                {
                    if (isWear)
                    {
                        _body = item;
                    }
                    else
                    {
                        _body = null;
                    }
                }
                break;
            case ItemType.Leg:
                {
                    if (isWear)
                    {
                        _leg = item;
                    }
                    else
                    {
                        _leg = null;
                    }
                }
                break;
        }

        ChangeStats(item, isWear);
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
