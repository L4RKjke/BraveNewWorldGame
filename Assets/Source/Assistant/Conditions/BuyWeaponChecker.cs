using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWeaponChecker : Condition
{
    [SerializeField] private PlayerItemStorage _itemStorage;

    private void Update()
    {
        if (_itemStorage.GetLenght() == 6)
        {
            NeedTransit = true;
        }
    }
}
