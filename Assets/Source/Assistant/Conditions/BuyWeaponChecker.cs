using UnityEngine;

public class BuyWeaponChecker : Condition
{
    [SerializeField] private PlayerItemStorage _itemStorage;
    [SerializeField] private int _newIdemsLenght;

    private void Update()
    {
        if (_itemStorage.GetLenght() == _newIdemsLenght)
        {
            NeedTransit = true;
        }
    }
}
