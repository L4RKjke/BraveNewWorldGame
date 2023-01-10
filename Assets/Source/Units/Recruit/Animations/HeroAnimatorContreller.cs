using UnityEngine;
using UnityEngine.Events;

public class HeroAnimatorContreller : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private RecruitAtackState _atackState;
    private WalkState _walkState;
    private CelebrationState _celebrationState;

    public UnityAction AtackCompleted;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        if (gameObject.transform.parent.TryGetComponent(out RecruitAtackState atackState))
            _atackState = atackState;

        if (gameObject.transform.parent.TryGetComponent(out WalkState walkState))
            _walkState = walkState;

        if (gameObject.transform.parent.TryGetComponent(out CelebrationState celebrateState))
            _celebrationState = celebrateState;

        _celebrationState.EnemiesDied += OnCelebrateState;
        _atackState.AtackStarted += OnHeroAtacking;
        _walkState.MovementStarted += OnHeroWalking;
    }

    private void OnDisable()
    {
        _celebrationState.EnemiesDied -= OnCelebrateState;
        _atackState.AtackStarted -= OnHeroAtacking;
        _walkState.MovementStarted -= OnHeroWalking;
    }

    public void OnHeroAtacking()
    {
        _animator.SetTrigger("CastSpell");
    }

    public void OnHeroWalking()
    {
        _animator.SetTrigger("Walk");
    }

    public void OnHeroDied()
    {
        _animator.SetTrigger("Died");
    }

    public void OnIdleAnimation()
    {
        _animator.SetTrigger("Idle");
    }

    public void OnCelebrateState()
    {
        _animator.SetTrigger("Idle");
    }

    public void OnAtackAnimationOver()
    {
        AtackCompleted?.Invoke();
    }
}