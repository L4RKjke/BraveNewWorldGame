using UnityEngine;

public class WolfAnimation : MonoBehaviour
{
    private Animator _animator;
    private EnemyAtackState _atackState;
    private WalkState _walkState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.fireEvents = false;

        if (gameObject.transform.parent.TryGetComponent(out EnemyAtackState atackState))
            _atackState = atackState;

        if (gameObject.transform.parent.TryGetComponent(out WalkState walkState))
            _walkState = walkState;

        _atackState.Atacked += OnAtack;
        _walkState.MovementStarted += OnWalk;
    }

    private void OnDisable()
    {
        _atackState.Atacked -= OnAtack;
        _walkState.MovementStarted -= OnWalk;
    }

    private void OnWalk()
    {
        _animator.SetBool("IsWalking", true);
        _animator.SetBool("IsAtacking", false);
    }

    private void OnAtack()
    {
        _animator.SetBool("IsAtacking", true);
        _animator.SetBool("IsWalking", false);
    }

    private void OnIdle()
    {
        _animator.SetBool("IsIdle", true);
    }
}
