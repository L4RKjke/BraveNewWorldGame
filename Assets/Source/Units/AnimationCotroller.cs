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

    protected Fighter CurrentUnit => _unit;

    protected Animator Animator { get; private set; }

    public UnityAction AtackCompleted;

    private void Start()
    {
        AtackCompleted += ShowDamageEffect;
        Animator = GetComponent<Animator>();
        _unit.Health.Died += OnUnitDied;

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
        AtackCompleted -= ShowDamageEffect;
        _unit.Health.Died -= OnUnitDied;
        StopCoroutine(_waitAtackAnimationCoroutine);

        if (_findTargetState != null)
            _findTargetState.StateActivated -= OnIdleAnimation;

        if (_atackState != null)
            _atackState.AtackStarted -= OnHeroAtacking;

        if (_walkState != null)
            _walkState.SpeedChanged -= OnHeroWalking;

        if (_meleeState != null)
            _meleeState.AtackStarted -= OnMelee;
    }

    public void OnHeroAtacking(UnityAction callback)
    {
        Animator.SetTrigger("Shoot");

        _waitAtackAnimationCoroutine = StartCoroutine(WaitForAnimationOver(callback));
    }

    public void OnHeroWalking(float speed)
    {
        Animator.SetFloat("Speed", speed);
    }

    public void OnIdleAnimation()
    {
        Animator.SetTrigger("Idle");
    }

    public void OnMelee(UnityAction callback)
    {
        Animator.SetTrigger("Atack");

        _waitAtackAnimationCoroutine = StartCoroutine(WaitForAnimationOver(callback));
    }

    private IEnumerator WaitForAnimationOver(UnityAction callback)
    {
        var animationLenght = Animator.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(animationLenght);

        Animator.SetTrigger("Idle");
        AtackCompleted?.Invoke();

        callback();
    }

    private void OnUnitDied(Fighter fighter)
    {
        var unit = Instantiate(_deathTemplate, transform.position, Quaternion.identity);
        unit.transform.localScale = _characterView.transform.localScale;
    }

    private void ShowDamageEffect()
    {
        if (this != null && _unit.CurrentTarget != null)
            Instantiate(_hitEffect, _unit.CurrentTarget.transform.position, Quaternion.identity);
    }
}