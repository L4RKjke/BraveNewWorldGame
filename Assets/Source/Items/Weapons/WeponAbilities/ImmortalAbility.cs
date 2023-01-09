using UnityEngine;

public class ImmortalAbility : WeaponAbility
{
    public override void ActivateAbility()
    {
        int randomUnitNumber = Random.Range(0, Fighter.Units.GetLength(FighterType.Recruit));
        Fighter friendlyUnit = Fighter.Units.GetById(randomUnitNumber, FighterType.Recruit);
        friendlyUnit.Imortaled?.Invoke();
    }
}
