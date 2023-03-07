using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    [SerializeField] private List<HeadItem> _headItems;
    [SerializeField] private List<BodyItem> _bodyItems;
    [SerializeField] private List<LegItem> _legItems;
    [SerializeField] private List<HandItem> _handItems;
    [SerializeField] private List<WeaponItem> _weaponItems;

    public int HeadCount => _headItems.Count;
    public int BodyCount => _bodyItems.Count;
    public int LegCount => _legItems.Count;
    public int HandCount => _handItems.Count;
    public int WeaponCount => _weaponItems.Count;

    public HeadItem GetHead (int id)
    {
        HeadItem temp = _headItems[id];
        return temp;
    }

    public BodyItem GetBody(int id)
    {
        BodyItem temp = _bodyItems[id];
        return temp;
    }

    public LegItem GetLeg(int id)
    {
        LegItem temp = _legItems[id];
        return temp;
    }

    public HandItem GetHand(int id)
    {
        HandItem temp = _handItems[id];
        return temp;
    }

    public WeaponItem GetWeapon(int id)
    {
        WeaponItem temp = _weaponItems[id];
        return temp;
    }
}
