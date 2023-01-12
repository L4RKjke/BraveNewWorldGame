using System.Collections;
using UnityEngine;

public class ImmortalAbility : WeaponAbility
{
    private float _immortalTime = 5;

    public override void ActivateAbility()
    {
        MakeImmortal();
    }

    private IEnumerator MakeImmortal()
    {
        int randomUnitNumber = Random.Range(0, Fighter.Units.GetLength(FighterType.Recruit));
        Fighter friendlyUnit = Fighter.Units.GetById(randomUnitNumber, FighterType.Recruit);

        friendlyUnit.MakeImmortal();

        yield return new WaitForSeconds(_immortalTime);

        friendlyUnit.MakeMortal();
    }
}
