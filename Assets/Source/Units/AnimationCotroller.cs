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

    private string _healthTxt;
    private float _damagedScale = 1.01f;
    private RangeAtackState _atackState;
    private WalkState _walkState;
    private FindTargetState _findTargetState;
    private MeleeState _meleeState;

    private readonly float _showTextTime = 0.3f;
    private readonly string _showText = "ShowHitEffect";

    protected Fighter CurrentUnit => _unit;

    protected Animator Animator { get; private set; }

    public UnityAction AtackCompleted;

    private void Start()
    {   
        Animator = GetComponent<Animator>();
        _unit.Health.Died += OnUnitDied;
        _unit.Health.HealthChanged += OnHealthChanged;

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
        _unit.Health.Died -= OnUnitDied;
        _unit.Health.HealthChanged -= OnHealthChanged;
        StopCoroutine(_showText);

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
        Animator.SetTrigger("Shoot");
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
        Animator.SetTrigger("Atack");
    }

    private void OnUnitDied(Fighter fighter)
    {
        var unit = Instantiate(_deathTemplate, transform.position, Quaternion.identity);
        unit.transform.localScale = _characterView.transform.localScale;
    }

    private void OnAtackAnimationOver()
    {
        AtackCompleted?.Invoke();
    }

    private void OnHealthChanged(int currentHealth)
    {
        _healthTxt = currentHealth.ToString();

        if (_TMPro != null)
            StartCoroutine(_showText);
    }

    private IEnumerator ShowHitEffect()
    {
        _TMPro.text = _healthTxt;
        _characterView.transform.localScale = _characterView.transform.localScale * _damagedScale;
        _TMPro.rectTransform.rotation = Quaternion.Euler(_TMPro.rectTransform.rotation.x, _TMPro.rectTransform.rotation.y, _TMPro.rectTransform.rotation.z + Random.Range(-10, 10));

        yield return new WaitForSeconds(_showTextTime);

        _characterView.transform.localScale = _characterView.transform.localScale / _damagedScale;
        _TMPro.text = "";
    }
}