using UnityEngine;

public class ScrabMonster : Fighter, IRangeAtacker
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Fire _fire;

    public void Shoot(int damage)
    {
        _fire.StartFire(Unit.Damage, CurrentTarget, _shootPoint);
    }
}