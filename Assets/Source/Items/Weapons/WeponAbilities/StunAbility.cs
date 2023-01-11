using System.Collections;
using UnityEngine;

public class StunAbility : WeaponAbility
{
    private float _stunTime = 3;

    override public void ActivateAbility()
    {
        StartCoroutine("Stun");
    }

    private void OnDisable()
    {
        StopCoroutine("Stun");
    }

    private IEnumerator Stun()
    {
        int randomUnitNumber = Random.Range(0, Fighter.Units.GetLength(FighterType.Enemy));
        Fighter enemyUnit = Fighter.Units.GetById(randomUnitNumber, FighterType.Enemy);
        enemyUnit.MakeUnmovable();

        yield return new WaitForSeconds(_stunTime);

        enemyUnit.MakeMoveble();
    }
}
