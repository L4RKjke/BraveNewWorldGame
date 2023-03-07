using UnityEngine;

public class WeaponItem : Item
{
    [SerializeField] private Sprite _weaponSprite;

    public Sprite WeaponSprite => _weaponSprite;
}
