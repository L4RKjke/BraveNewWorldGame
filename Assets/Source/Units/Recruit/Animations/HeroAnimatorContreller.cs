using UnityEngine;

public class HeroAnimatorContreller : AnimationCotroller
{
    private RecruitAtackState _atackState;
    private WalkState _walkState;
    private FindTargetState _findTargetState;
    private MeleeState _meleeState;

    private void Start()
    {
        if (CurrentUnit != null)
        {
            /*CurrentUnit.HealthChanged += OnHitted;*/

            if (CurrentUnit.TryGetComponent(out RecruitAtackState atackState))
            {
                _atackState = atackState;
                _atackState.RangeAtackStarted += OnHeroAtacking;
            }

            if (CurrentUnit.TryGetComponent(out WalkState walkState))
            {
                _walkState = walkState;
                _walkState.MovementStarted += OnHeroWalking;
            }

            if (CurrentUnit.TryGetComponent(out FindTargetState findTarget))
            {
                _findTargetState = findTarget;
                _findTargetState.StateActivated += OnIdleAnimation;
            }

            if (CurrentUnit.TryGetComponent(out MeleeState melee))
            {
                _meleeState = melee;
                _meleeState.MelleeAtackStarted += OnMelee;
            }
        }
    }

    private void OnDisable()
    {
        if (_findTargetState != null)
            _findTargetState.StateActivated -= OnIdleAnimation;

        if (_atackState != null)
            _atackState.RangeAtackStarted -= OnHeroAtacking;

        if (_walkState != null)
            _walkState.MovementStarted -= OnHeroWalking;

        if (_meleeState != null)
            _meleeState.MelleeAtackStarted -= OnMelee;
/*
        if (CurrentUnit != null)
            CurrentUnit.HealthChanged -= OnHitted;*/
    }

    public void OnHeroAtacking()
    {
        Animator.SetTrigger("CastSpell");
    }

    public void OnHeroWalking()
    {
        Animator.SetTrigger("Walk");
    }

    public void OnIdleAnimation()
    {
        Animator.SetTrigger("Idle");
    }

    public void OnMelee()
    {
        Animator.SetTrigger("HandAtack");
    }

    public void OnHitted(ushort damage)
    {
        Animator.SetTrigger("Hitted");
    }
}