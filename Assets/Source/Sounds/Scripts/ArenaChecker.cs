using UnityEngine;
using UnityEngine.Events;

public class ArenaChecker : MonoBehaviour
{
    public UnityAction ArenaEnabled;
    public UnityAction ArenaDisabled;

    private void OnEnable()
    {
        ArenaEnabled?.Invoke();
    }

    private void OnDisable()
    {
        ArenaDisabled?.Invoke();
    }
}