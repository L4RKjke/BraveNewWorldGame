using System.Collections;
using UnityEngine;

public class ImmortalAbility : WeaponAbility
{
    private float _immortalTime = 15;

    public override void ActivateAbility()
    {
        StartCoroutine("MakeImmortal");
    }

    private void OnDisable()
    {
        StopCoroutine("MakeImmortal");
    }

    private IEnumerator MakeImmortal()
    {
        Debug.Log("ImmortalTest");

        int randomUnitNumber = Random.Range(0, Fighter.Units.GetLength(FighterType.Recruit));
        Fighter friendlyUnit = Fighter.Units.GetById(randomUnitNumber, FighterType.Recruit);

        friendlyUnit.MakeImmortal();

        yield return new WaitForSeconds(_immortalTime);

        friendlyUnit.MakeMortal();
    }
}
