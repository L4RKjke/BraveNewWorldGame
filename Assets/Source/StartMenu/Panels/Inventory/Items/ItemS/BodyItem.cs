using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyItem : Item
{
    [SerializeField] private Sprite _armorSprite;
    [SerializeField] private Sprite _armRight;
    [SerializeField] private Sprite _armLeft;

    public Sprite ArmorSprite => _armorSprite;
    public Sprite ArmLeft => _armLeft;
    public Sprite ArmRight => _armRight;
}
