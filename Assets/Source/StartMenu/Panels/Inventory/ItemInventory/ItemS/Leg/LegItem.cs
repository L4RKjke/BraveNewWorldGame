using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegItem : Item
{
    [SerializeField] private Sprite _legRight;
    [SerializeField] private Sprite _legLeft;

    public Sprite LegRight => _legRight;
    public Sprite LegLeft => _legLeft;
}
