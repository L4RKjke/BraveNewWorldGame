using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public abstract class AnimationCotroller : MonoBehaviour
{
    [SerializeField] private Fighter _unit;
    [SerializeField] private GameObject _deathTemplate;

    protected Fighter CurrentUnit => _unit;

    protected Animator Animator { get; private set; }

    public UnityAction AtackCompleted;

    private void OnEnable()
    {   
        Animator = GetComponent<Animator>();
        _unit.Died += OnUnitDied;
    }

    private void OnDisable()
    {
        _unit.Died -= OnUnitDied;
    }

    private void OnUnitDied(Fighter fighter)
    {
        Instantiate(_deathTemplate, transform.position, Quaternion.Euler(fighter.transform.localScale));
    }

    private void OnAtackAnimationOver()
    {
        AtackCompleted?.Invoke();
    }
}