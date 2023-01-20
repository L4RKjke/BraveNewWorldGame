using UnityEngine;

public class HeroAnimatorContreller : AnimationCotroller
{
    private RangeAtackState _atackState;
    private WalkState _walkState;
    private FindTargetState _findTargetState;
    private MeleeState _meleeState;

    private void Start()
    {
        if (CurrentUnit != null)
        {
            if (CurrentUnit.TryGetComponent(out RangeAtackState atackState))
            {
                _atackState = atackState;
                _atackState.AtackStarted += OnHeroAtacking;
            }

            if (CurrentUnit.TryGetComponent(out WalkState walkState))
            {
                _walkState = walkState;
                _walkState.SpeedChanged += OnHeroWalking;
            }

            if (CurrentUnit.TryGetComponent(out FindTargetState findTarget))
            {
                _findTargetState = findTarget;
                _findTargetState.StateActivated += OnIdleAnimation;
            }

            if (CurrentUnit.TryGetComponent(out MeleeState melee))
            {
                _meleeState = melee;
                _meleeState.AtackStarted += OnMelee;
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
            _walkState.SpeedChanged -= OnHeroWalking;

        if (_meleeState != null)
            _meleeState.AtackStarted -= OnMelee;
    }

    public void OnHeroAtacking()
    {
        Animator.SetTrigger("CastSpell");
    }

    public void OnHeroWalking(float speed)
    {
        Animator.SetFloat("Speed", speed);
    }

    public void OnIdleAnimation()
    {
        Animator.SetTrigger("Idle");
    }

    public void OnMelee()
    {
        Animator.SetTrigger("HandAtack");
    }
}