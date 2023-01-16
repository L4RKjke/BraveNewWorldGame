using UnityEngine;

public abstract class DistanceChecker : Transition
{
    protected float AtackDistance => CurrentFighter.AtackDistance;

    protected float DistanceToTarget => Vector2.Distance(transform.position, CurrentFighter.CurrentTarget.transform.position);
}
