using UnityEngine.Events;

public class FindTargetState : State
{
    public UnityAction StateActivated;

    /// Заменить если шо на апдейт, чтобы все работало

    private void OnEnable()
    {
        GetComponent<Fighter>().UpdateCurrentTarget();
        StateActivated?.Invoke();
    }
}
