using System.Collections;
using UnityEngine;

public class StunAbility : WeaponAbility
{
    private float _stunTime = 3;

    private readonly string _stun = "Stun";

    override public void ActivateAbility()
    {
        StartCoroutine(_stun);
    }

    private void OnDisable()
    {
        StopCoroutine(_stun);
    }

    private IEnumerator Stun()
    {
        if (Fighter != null)
        {
            int randomUnitNumber = Random.Range(0, Fighter.Units.GetLength(FighterType.Enemy));

            if (randomUnitNumber != 0)
            {
                Fighter enemyUnit = Fighter.Units.GetById(randomUnitNumber, FighterType.Enemy);
                enemyUnit.MakeUnmovable();

                yield return new WaitForSeconds(_stunTime);

                enemyUnit.MakeMoveble();
            }
        }
    }
}
