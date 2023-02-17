using UnityEngine;

public class Condition : MonoBehaviour
{
    [SerializeField] private Task _targetTask;

    public bool NeedTransit { get; protected set; }

    public Task TargetTask => _targetTask;

    private void OnEnable()
    {
        NeedTransit = false;
    }

    private void OnDisable()
    {
        NeedTransit = true;
    }
}
