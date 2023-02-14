using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Task : MonoBehaviour
{
    [TextArea(3, 10)] [SerializeField] private string _destription;
    [SerializeField] private List<Condition> _transitions;

    public UnityAction<Task> TaskActivated;

    public string Destription => _destription;

    protected Vector2 TargetPosition;

    public Fighter CurrentFighter => GetComponent<Fighter>();

    public void Enter()
    {
        if (enabled == false)
        {
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                TaskActivated?.Invoke(this);
            }
        }
    }

    public Task GetNext()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetTask;
            }
        }

        return null;
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }
}
