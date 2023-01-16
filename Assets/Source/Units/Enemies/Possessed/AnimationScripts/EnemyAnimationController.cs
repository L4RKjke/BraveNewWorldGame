using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private GameObject _deathTemplate;
    [SerializeField] private Enemy _enemy;

    private Animator _animator;
    private EnemyAtackState _atackState;
    private WalkState _walkState;
    private FindTargetState _findTargetState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.fireEvents = false;


        _enemy.Died += OnEnemieDied;

        if (_enemy.TryGetComponent(out EnemyAtackState atackState))
            _atackState = atackState;

        if (_enemy.TryGetComponent(out WalkState walkState))
            _walkState = walkState;
        if (_enemy.TryGetComponent(out FindTargetState findTarget))
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

    private void OnEnemieDied(Fighter fighter)
    {
        Instantiate(_deathTemplate, transform.position, Quaternion.identity);
    }
}
