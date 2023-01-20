using UnityEngine;

public class DistanceTransition : Transition
{
    public float DistanceToTarget => Vector2.Distance(transform.position, CurrentFighter.CurrentTarget.transform.position);
}
