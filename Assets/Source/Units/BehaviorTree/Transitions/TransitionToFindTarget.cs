public class TransitionToFindTarget : Transition
{
    private void Update()
    {
        if (CurrentFighter.CurrentTarget == null)
        {
            NeedTransit = true;
        }
    }
}
