using UnityEngine.Events;

public class FindTargetState : State
{
    public UnityAction StateActivated;

    private void OnEnable()
    {
        CurrentFighter.UpdateCurrentTarget();
        StateActivated?.Invoke();
    }
}
