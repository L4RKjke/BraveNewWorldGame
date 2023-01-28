using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorItemRender : ItemRender
{
    protected override void ChangeHand(bool isWear, Item item)
    {
        if (item.Type == ItemType.Hand)
        {
            HandItem temp = item.GetComponent<HandItem>();

            if (isWear)
            {
                if (temp.IsWeapon)
                    PrimaryWeapon.sprite = temp.RightHand;
                else
                    Sleeve.sprite = temp.RightHand;
            }
            else
            {
                Sleeve.sprite = null;
                PrimaryWeapon.sprite = null;
            }
        }
        else
        {
            if (isWear)
            {
                PrimaryWeapon.sprite = item.GetComponent<WeaponItem>().WeaponSprite;
            }
            else
            {
                PrimaryWeapon.sprite = null;
            }
        }
    }

    protected override void ChangeWeapon(bool isWear, Item item)
    {
        if (isWear)
        {
            SecondaryWeapon.sprite = item.GetComponent<WeaponItem>().WeaponSprite;
        }
        else
        {
            SecondaryWeapon.sprite = null;
        }
    }
}
