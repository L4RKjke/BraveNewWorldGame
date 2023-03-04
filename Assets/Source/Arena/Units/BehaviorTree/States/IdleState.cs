using UnityEngine.Events;

public class IdleState : State
{
    public UnityAction StateActivated;

    private void OnEnable()
    {
        StateActivated?.Invoke();
    }
}
