using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Vector2 TargetPosition;

    public Fighter CurrentFighter => GetComponent<Fighter>();

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