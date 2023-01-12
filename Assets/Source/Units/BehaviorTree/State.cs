using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected UnityEngine.AI.NavMeshAgent Agent { get; private set; }

    protected Fighter Fighter { get; private set; }

    protected Vector2 TargetPosition;

    private void Awake()
    {
        Fighter = GetComponent<Fighter>();
    }

    public void Enter ()
    {
        if(enabled == false)
        {
            enabled = true;

            foreach (var transition in _transitions) 
            {
                transition.enabled = true;
            }
        }
    }

    public State GetNext ()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }
        
        return null;
    }

    public void Exit()
    {
        if(enabled)
        {
            foreach(var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }
}
