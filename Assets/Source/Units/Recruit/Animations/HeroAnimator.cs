using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    private Animator _animator;
    private RecruitAtackState _atackState;
    private WalkState _walkState;
    private CelebrationState _celebrationState;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _animator.fireEvents = false;

        if (gameObject.transform.parent.TryGetComponent(out RecruitAtackState atackState))
            _atackState = atackState;

        if (gameObject.transform.parent.TryGetComponent(out WalkState walkState))
            _walkState = walkState;

        if (gameObject.transform.parent.TryGetComponent(out CelebrationState celebrateState))
            _celebrationState = celebrateState;

        _celebrationState.EnemiesDied += OnIdleAnimation;
        _atackState.RecruitAtacked += OnHeroAtacking;
        _walkState.MovementStarted += OnHeroWalking;
    }

    private void OnDisable()
    {
        _celebrationState.EnemiesDied -= OnIdleAnimation;
        _atackState.RecruitAtacked -= OnHeroAtacking;
        _walkState.MovementStarted -= OnHeroWalking;
    }

    public void OnHeroAtacking()
    {
        _animator.SetTrigger("CastSpell");
    }

    public void OnHeroWalking()
    {
        _animator.SetBool("IsWallking", true);
    }

    public void OnHeroDied()
    {
        _animator.SetTrigger("Died");
    }

    public void OnIdleAnimation()
    {
        _animator.SetTrigger("Idle");
    }
}