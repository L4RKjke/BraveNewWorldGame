using UnityEngine;

public class ScrabMonster : Fighter, IRangeAtacker
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Fire _fire;

    public void Shoot(int damage)
    {
        _fire.StartFire(Unit.Damage, Unit.CurrentTarget, _shootPoint);
    }

    public float GetRangeAtackDelay()
    {
        return AtackDelay;
    }
}