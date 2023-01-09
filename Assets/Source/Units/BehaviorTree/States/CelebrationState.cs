using UnityEngine.Events;
using UnityEngine;

public class CelebrationState : State
{
    public UnityAction EnemiesDied;

    private void OnEnable()
    {
        EnemiesDied?.Invoke();
    }
}
