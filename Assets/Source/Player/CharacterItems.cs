using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterItems : MonoBehaviour
{
    private CharacterStats _characterStats;
    private Item _head;
    private Item _body;
    private Item _leg;
    private Item _hand;
    private Item _weapon;

    private void Awake()
    {
        _characterStats = GetComponent<CharacterStats>();
    }

    public Item GetItem(string type)
    {
        type.ToLower();

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
        type.ToLower();

        switch (type)
        {
            case "weapon":
                Equip(isWear, _weapon, item);
                break;
            case "hand":
                Equip(isWear, _hand, item);
                break;
            case "head":
                Equip(isWear, _head, item);
                break;
            case "body":
                Equip(isWear, _body, item);
                break;
            case "leg":
                Equip(isWear, _leg, item);
                break;
        }
    }

    private void Equip(bool isWear, Item characterItem, Item equipItem)
    {
        if (isWear)
            characterItem = equipItem;
        else
            characterItem = null;
    }
}
