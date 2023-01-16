using UnityEngine;
using UnityEngine.AI;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    public Fighter CurrentFighter { get; protected set; }

    private void Awake()
    {
        CurrentFighter = GetComponent<Fighter>();
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }

    private void OnDisable()
    {
        NeedTransit = true;
    }
}
