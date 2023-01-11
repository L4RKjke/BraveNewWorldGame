public class TransitionToFindTarget : Transition
{
    private void Update()
    {
        if (CurrentFighter.CurrentTarget == null /*&& CurrentFighter.Units.GetLength(CurrentFighter.EnemyType) == 0*/)
        {
            NeedTransit = true;
        }
    }
}
