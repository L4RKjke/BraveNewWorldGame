using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private Task _firstTask;

    private Task _currentTask;

    public Task CurrentTask => _currentTask;

    public UnityAction<Task> TransitCompleted;

    private void Start()
    {
        ResetTask(_firstTask);
        TransitCompleted?.Invoke(_currentTask);
    }

    private void Update()
    {
        if (_currentTask == null)
            return;

        Task nextState = _currentTask.GetNext();

        if (nextState != null)
            Transit(nextState);

    }

    private void ResetTask(Task startState)
    {
        _currentTask = startState;

        if (_currentTask != null)
            _currentTask.Enter();
    }

    private void Transit(Task nextState)
    {
        if (_currentTask != null)
        {
            _currentTask.Exit();
        }

        _currentTask = nextState;

        if (_currentTask != null)
        {
            _currentTask.Enter();
            TransitCompleted?.Invoke(_currentTask);
        }
    }
}
