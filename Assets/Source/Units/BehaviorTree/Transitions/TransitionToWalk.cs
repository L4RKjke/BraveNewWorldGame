using UnityEngine;

public class TransitionToWalk : DistanceChecker
{
     [SerializeField] private float _atackDistance = 1.2f;

    private void Update()
    {
        if (CurrentFighter.CurrentTarget != null)
            if (DistanceToTarget >= _atackDistance)
            {
                NeedTransit = true;
            }
    }
}
