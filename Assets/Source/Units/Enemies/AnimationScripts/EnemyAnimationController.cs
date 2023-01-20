using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimationController : AnimationCotroller
{
    private RangeAtackState _atackState;
    private WalkState _walkState;
    private FindTargetState _findTargetState;
    private MeleeState _meleeState;

    public UnityAction AtackComplete;

    private void Start()
    {
        if (CurrentUnit != null)
        {
            if (CurrentUnit.TryGetComponent(out MeleeState melee))
                _meleeState = melee;

            if (CurrentUnit.TryGetComponent(out RangeAtackState atackState))
                _atackState = atackState;

            if (CurrentUnit.TryGetComponent(out WalkState walkState))
                _walkState = walkState;

            if (CurrentUnit.TryGetComponent(out FindTargetState findTarget))
                _findTargetState = findTarget;

            if (_findTargetState != null)
                _findTargetState.StateActivated += OnIdle;
            if (_atackState != null)
                _atackState.AtackStarted += OnRangeAtack;
            if (_walkState != null)
                _walkState.SpeedChanged += OnWalk;
            if (_meleeState != null)
                _meleeState.AtackStarted += OnAtack;
        }
    }

    private void OnDisable()
    {
        if (_atackState != null)
            _atackState.AtackStarted -= OnRangeAtack;
        if (_walkState != null)
            _walkState.SpeedChanged -= OnWalk;
        if (_findTargetState != null)
            _findTargetState.StateActivated -= OnIdle;
        if (_meleeState != null)
            _meleeState.AtackStarted -= OnAtack;
    }

    private void OnWalk(float speed)
    {
        Animator.SetTrigger("Walk");
    }

    private void OnAtack()
    {
        Animator.SetTrigger("Atack");
    }

    private void OnRangeAtack()
    {
        Animator.SetTrigger("Shoot");
    }

    private void OnIdle()
    {
        Animator.SetTrigger("Idle");
    }
}
