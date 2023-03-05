using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public abstract class AtackState : State
{
    [SerializeField] private AnimationCotroller _animationController;

    private Coroutine _atackCourutine;

    protected AnimationCotroller AnimationController => _animationController;

    protected int Damage => CurrentFighter.Damage;

    public float FirstDelaySpread => Random.Range(0.05f, 0.11f);

    public UnityAction AtackStarted;
    public UnityAction AtackCompleted;
    public UnityAction StateActivated;

    private void OnEnable()
    {
        AnimationController.AtackCompleted += CompleteAtack;
        AnimationController.AtackAnimationCompleted += StartRoutine;
        _atackCourutine = StartCoroutine(LaunchAtack(FirstDelaySpread));
        StateActivated?.Invoke();
    }

    private void OnDisable()
    {
        AnimationController.AtackCompleted -= CompleteAtack;
        AnimationController.AtackAnimationCompleted -= StartRoutine;
        StopCoroutine(_atackCourutine);
    }

    protected abstract float CurrentDelay();

    protected abstract void StartAtack();

    protected abstract void CompleteAtack();
    

    private IEnumerator LaunchAtack(float atackDelay)
    {
            yield return new WaitForSeconds(atackDelay);

            StartAtack();
    }

    private void StartRoutine()
    {
        if (_atackCourutine != null)
            StopCoroutine(_atackCourutine);

        _atackCourutine = StartCoroutine(LaunchAtack(CurrentDelay()));
    }
}