using UnityEngine;
using UnityEngine.AI;

public class TransitionToWalk : Transition
{
    private void Update()
    {
        if (CurrentFighter.CurrentTarget != null)
            if (Vector2.Distance(transform.position, CurrentFighter.CurrentTarget.transform.position) > Agent.stoppingDistance)
            {
                NeedTransit = true;
            }
    }
}
