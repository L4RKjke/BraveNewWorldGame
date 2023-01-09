using UnityEngine;

public class StunAbility : WeaponAbility
{
    override public void ActivateAbility()
    {
        int randomUnitNumber = Random.Range(0, Fighter.Units.GetLength(FighterType.Enemy));
        Fighter enemyUnit = Fighter.Units.GetById(randomUnitNumber, FighterType.Enemy);
        enemyUnit.Stunned?.Invoke();
    }
}
