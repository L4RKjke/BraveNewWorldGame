using UnityEngine;
using UnityEngine.Events;

public class HeroAnimatorContreller : MonoBehaviour
{
    [SerializeField] private Recruit _recruit;
    [SerializeField] private GameObject _deathTemplate;

    private Animator _animator;
    private RecruitAtackState _atackState;
    private WalkState _walkState;
    private FindTargetState _findTargetState;
    private MeleeState _meleeState;

    public UnityAction AtackCompleted;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        if (_recruit != null)
        {
            _recruit.Died += OnHeroDied;

            if (_recruit.TryGetComponent(out RecruitAtackState atackState))
            {
                _atackState = atackState;
                _atackState.AtackStarted += OnHeroAtacking;
            }

            if (_recruit.TryGetComponent(out WalkState walkState))
            {
                _walkState = walkState;
                _walkState.MovementStarted += OnHeroWalking;
            }

            if (_recruit.TryGetComponent(out FindTargetState findTarget))
            {
                _findTargetState = findTarget;
                _findTargetState.StateActivated += OnIdleAnimation;
            }

            if (_recruit.TryGetComponent(out MeleeState melee))
            {
                _meleeState = melee;
                _meleeState.StateActivated += OnMelee;
            }
        }
    }

    private void OnDisable()
    {
        if (_findTargetState != null)
            _findTargetState.StateActivated -= OnIdleAnimation;

        if (_atackState != null)
            _atackState.AtackStarted -= OnHeroAtacking;

        if (_walkState != null)
            _walkState.MovementStarted -= OnHeroWalking;

        if (_meleeState != null)
            _meleeState.StateActivated -= OnMelee;
    }

    public void OnHeroAtacking()
    {
        _animator.SetTrigger("CastSpell");
    }

    public void OnHeroWalking()
    {
        _animator.SetTrigger("Walk");
    }

    public void OnHeroDied(Fighter fighter)
    {
        Instantiate(_deathTemplate, transform.position, Quaternion.Euler(fighter.transform.localScale));
    }

    public void OnIdleAnimation()
    {
        _animator.SetTrigger("Idle");
    }

    public void OnMelee()
    {
        _animator.SetTrigger("HandAtack");
    }

    public void OnAtackAnimationOver()
    {
        AtackCompleted?.Invoke();
    }
}