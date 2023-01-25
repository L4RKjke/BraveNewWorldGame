using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Appearance))]
public abstract class ItemRender : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _armor; //
    [SerializeField] private SpriteRenderer _helmet; //
    [SerializeField] private SpriteRenderer _armRightArmor; //
    [SerializeField] private SpriteRenderer _armLeftArmor; //
    [SerializeField] private SpriteRenderer _legRightArmor; //
    [SerializeField] private SpriteRenderer _legLeftArmor; //
    [SerializeField] private GameObject _headAnchor;

    [SerializeField] protected SpriteRenderer PrimaryWeapon; //
    [SerializeField] protected SpriteRenderer SecondaryWeapon; //
    [SerializeField] protected SpriteRenderer Shield; //
    [SerializeField] protected SpriteRenderer Sleeve; //
    [SerializeField] protected SpriteRenderer BackQuiver;

    public GameObject Head => _headAnchor;

    public void ChangeItem(ItemType type, bool isWear, Item item, bool isHand)
    {
        switch (type)
        {
            case ItemType.Weapon:
                {
                    if (isHand == false)
                    {
                        ChangeWeapon(isWear, item);
                    }
                    else
                    {
                        ChangeHand(isWear, item);
                    }
                }
                break;
            case ItemType.Hand:
                {
                    ChangeHand(isWear, item);
                }
                break;
            case ItemType.Head:
                {
                    ChangeHead(isWear, item);
                }
                break;
            case ItemType.Body:
                {
                    ChangeBody(isWear, item);
                }
                break;
            case ItemType.Leg:
                {
                    ChangeLeg(isWear, item);
                }
                break;
        }
    }

    protected virtual void ChangeHand(bool isWear, Item item)
    {
        if (item.Type == ItemType.Hand)
        {
            if (isWear)
            {
                Shield.sprite = item.GetComponent<HandItem>().LeftHand;
            }
            else
            {
                Shield.sprite = null;
            }
        }
        else
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

    protected virtual void ChangeWeapon(bool isWear, Item item)
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

    private void ChangeHead(bool isWear, Item item)
    {
        gameObject.GetComponent<Appearance>().ChangeHelmItem(isWear);

        if (isWear)
        {
            _helmet.sprite = item.GetComponent<HeadItem>().Head;
        }
        else
        {
            _helmet.sprite = null;
        }
    }

    private void ChangeLeg(bool isWear, Item item)
    {
        if (isWear)
        {
            _legRightArmor.sprite = item.GetComponent<LegItem>().LegRight;
            _legLeftArmor.sprite = item.GetComponent<LegItem>().LegLeft;
        }
        else
        {
            _legLeftArmor.sprite = null;
            _legRightArmor.sprite = null;
        }
    }

    private void ChangeBody(bool isWear, Item item)
    {
        if (isWear)
        {
            _armor.sprite = item.GetComponent<BodyItem>().ArmorSprite;
        }
        else
        {
            TakeOfArmor();
        }
    }

    private void TakeOfArmor()
    {
        _armor.sprite = gameObject.GetComponent<Appearance>().StandartArmor;
    }
}
