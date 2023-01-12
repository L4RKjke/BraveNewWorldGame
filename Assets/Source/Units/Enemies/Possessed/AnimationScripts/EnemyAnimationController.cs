using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;
    private EnemyAtackState _atackState;
    private WalkState _walkState;
    private FindTargetState _findTargetState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.fireEvents = false;

        if (gameObject.transform.parent.TryGetComponent(out EnemyAtackState atackState))
            _atackState = atackState;

        if (gameObject.transform.parent.TryGetComponent(out WalkState walkState))
            _walkState = walkState;
        if (gameObject.transform.parent.TryGetComponent(out FindTargetState findTarget))
            _findTargetState = findTarget;

        _findTargetState.StateActivated += OnIdle;
        _atackState.Atacked += OnAtack;
        _walkState.MovementStarted += OnWalk;
    }

    private void OnDisable()
    {
        _atackState.Atacked -= OnAtack;
        _walkState.MovementStarted -= OnWalk;
        _findTargetState.StateActivated -= OnIdle;
    }

    private void OnWalk()
    {
        _animator.SetTrigger("Walk");
    }

    private void OnAtack()
    {
        _animator.SetTrigger("Atack");
    }

    private void OnIdle()
    {
        _animator.SetTrigger("Idle");
    }
}
