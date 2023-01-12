using UnityEngine.Events;
using UnityEngine;

public class MeleeState : AtackState
{
    [SerializeField] private HeroAnimatorContreller _controller;

    public UnityAction StateActivated;

    private void OnEnable()
    {
        StartCoroutine("LaunchActack");

        _controller.AtackCompleted += OnAtackComplete;
    }

    private void OnDisable()
    {
        StopCoroutine("LaunchActack");

        _controller.AtackCompleted -= OnAtackComplete;
    }

    override protected void StartAtack()
    {
        StateActivated?.Invoke();
    }

    private void OnAtackComplete()
    {
        Fighter.CurrentTarget.TakeDamage(20);
    }
}
