using UnityEngine.Events;

public class FindTargetState : State
{
    public UnityAction EnemyDied;

    private void OnEnable()
    {
        EnemyDied?.Invoke();
        GetComponent<Fighter>().UpdateCurrentTarget();
    }
}
