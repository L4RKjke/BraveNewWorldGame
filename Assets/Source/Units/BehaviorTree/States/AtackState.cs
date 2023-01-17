using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class AtackState : State
{
    [SerializeField] private AnimationCotroller _controller;

    private readonly float _atackDelay = 2;

    protected AnimationCotroller Controller => _controller;

    protected readonly string Launch  = "LaunchActack";
    protected abstract void StartAtack();

    protected abstract void CompleteAtack();

    protected IEnumerator LaunchActack()
    {
        while (true)
        {
            StartAtack();
            yield return new WaitForSeconds(_atackDelay);
        }
    }
}
