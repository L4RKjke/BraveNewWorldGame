using UnityEngine;

public class TransitionToRangeAtack : DistanceTransition
{
    private void Update()
    {
        if (CurrentFighter.CurrentTarget != null)
            if (DistanceToTarget <= CurrentFighter.WalkDistance)
            {
                NeedTransit = true;
            }
    }
}