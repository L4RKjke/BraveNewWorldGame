using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class AnimationCotroller : MonoBehaviour
{
    [SerializeField] private Fighter _unit;
    [SerializeField] private GameObject _deathTemplate;
    [SerializeField] private TextMeshProUGUI _TMPro;
    [SerializeField] private GameObject _characterView;
    [SerializeField] private GameObject _hitEffect;

    private RangeAtackState _atackState;
    private WalkState _walkState;
    private FindTargetState _findTargetState;
    private MeleeState _meleeState;
    private Coroutine _waitAtackAnimationCoroutine;

    private readonly string _idleAnimation = "Idle";
    private readonly string _shootAnitmation = "Shoot";
    private readonly string _walkAnimation = "Speed";
    private readonly string _atackAnimation = "Atack";
    private readonly string _atackLeftAnimation = "AtackLeft";


    protected Fighter CurrentUnit => _unit;

    protected Animator Animator { get; private set; }

    public UnityAction AtackCompleted;
    public UnityAction AtackAnimationCompleted;


    private void Start()
    {
        Animator = GetComponent<Animator>();
        _unit.Health.Died += OnUnitDied;
        AtackCompleted += ShowDamageEffect;

        if (CurrentUnit != null)
        {
            if (CurrentUnit.TryGetComponent(out RangeAtackState atackState))
            {
                _atackState = atackState;
                _atackState.AtackStarted += OnHeroAtacking;
                _atackState.StateActivated += OnIdleAnimation;
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
                _meleeState.StateActivated += OnIdleAnimation;
            }
        }
    }

    private void OnDisable()
    {
        AtackCompleted -= ShowDamageEffect;

        if (_unit.Health != null)
        {
            _unit.Health.Died -= OnUnitDied;
        }

        if (_waitAtackAnimationCoroutine is not null)
            StopCoroutine(_waitAtackAnimationCoroutine);

        if (_findTargetState != null)
            _findTargetState.StateActivated -= OnIdleAnimation;

        if (_atackState != null)
        {
            _atackState.AtackStarted -= OnHeroAtacking;
            _atackState.StateActivated -= OnIdleAnimation;
        }

        if (_walkState != null)
            _walkState.SpeedChanged -= OnHeroWalking;

        if (_meleeState != null)
        {
            _meleeState.AtackStarted -= OnMelee;
            _meleeState.StateActivated -= OnIdleAnimation;
        }
    }

    public void OnHeroAtacking()
    {
        Animator.SetTrigger(_shootAnitmation);
    }

    public void OnHeroWalking(float speed)
    {
        Animator.SetFloat(_walkAnimation, speed);
    }

    public void OnIdleAnimation()
    {
        Animator.SetTrigger(_idleAnimation);
    }

    public void OnMelee()
    {
        if (CurrentUnit.TryGetComponent<Warrior>(out _))
            Animator.SetTrigger(_atackLeftAnimation);
        else
            Animator.SetTrigger(_atackAnimation);
    }

    private void OnAnimationOver() 
    {
        AtackAnimationCompleted?.Invoke();
    }

    private void OnAtackOver()
    {
        AtackCompleted?.Invoke();
    }

    private void OnUnitDied(Fighter fighter)
    {
        if (this != null && _unit != null)
        {
            var unit = Instantiate(_deathTemplate, transform.position, Quaternion.identity);
            unit.transform.localScale = _characterView.transform.localScale;
        }
    }

    private void ShowDamageEffect()
    {
        if (this != null && _unit.CurrentTarget != null)
            Instantiate(_hitEffect, _unit.CurrentTarget.transform.position, Quaternion.identity);
    }
}