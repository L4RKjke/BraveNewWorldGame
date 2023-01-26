using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandItem : Item
{
    [SerializeField] private Sprite _rightHand;
    [SerializeField] private Sprite _leftHand;

    public Sprite RightHand => _rightHand;
    public Sprite LeftHand => _leftHand;
}
