using UnityEngine;
using UnityEngine.AI;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected NavMeshAgent Agent { get; private set; }

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    public Fighter CurrentFighter { get; protected set; }

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
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
