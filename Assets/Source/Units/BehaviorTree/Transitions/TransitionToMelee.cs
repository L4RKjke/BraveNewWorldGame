using UnityEngine;

public class TransitionToMelee : Transition
{
    private readonly float _meleeDistance = 1.3f;

    private void Update()
    {
        if (CurrentFighter.CurrentTarget != null)
            if (Vector2.Distance(transform.position, CurrentFighter.CurrentTarget.transform.position) < _meleeDistance)
            {
                NeedTransit = true;
            }
    }
}