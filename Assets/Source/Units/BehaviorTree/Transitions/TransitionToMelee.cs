using UnityEngine;

public class TransitionToMelee : DistanceTransition
{
    private void Update()
    {
        if (CurrentFighter.CurrentTarget != null)
            if (DistanceToTarget < CurrentFighter.MeleeDistance)
            {
                NeedTransit = true;
            }
    }
}