using System.Collections;
using UnityEngine;

public class ImmortalAbility : WeaponAbility
{
    private float _immortalTime = 15;

    private readonly string _makeImmortal = "MakeImmortal";

    public override void ActivateAbility()
    {
        StartCoroutine(_makeImmortal);
    }

    private void OnDisable()
    {
        StopCoroutine(_makeImmortal);
    }

    private IEnumerator MakeImmortal()
    {
        if (Fighter != null)
        {
            int randomUnitNumber = Random.Range(0, Fighter.Units.GetLength(FighterType.Recruit));
            Fighter friendlyUnit = Fighter.Units.GetById(randomUnitNumber, FighterType.Recruit);

            friendlyUnit.MakeImmortal();

            yield return new WaitForSeconds(_immortalTime);

            friendlyUnit.MakeMortal();
        }
    }
}
