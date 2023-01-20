using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadItem : Item
{
    [SerializeField] private Sprite _head;

    public Sprite Head => _head;
}
