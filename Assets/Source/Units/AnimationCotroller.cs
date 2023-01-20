using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public abstract class AnimationCotroller : MonoBehaviour
{
    [SerializeField] private Fighter _unit;
    [SerializeField] private GameObject _deathTemplate;
    [SerializeField] private TextMeshProUGUI _TMPro;
    [SerializeField] private GameObject _characterView;

    private string _healthTxt;
    private float _damagedScale = 1.01f;

    private readonly float _showTextTime = 0.3f;
    private readonly string _showText = "ShowText";

    protected Fighter CurrentUnit => _unit;

    protected Animator Animator { get; private set; }

    public UnityAction AtackCompleted;

    private void OnEnable()
    {   
        Animator = GetComponent<Animator>();
        _unit.Died += OnUnitDied;
        _unit.HealthChanged += OnHealthChanged;


    }

    private void OnDisable()
    {
        _unit.Died -= OnUnitDied;
        _unit.HealthChanged -= OnHealthChanged;
        StopCoroutine(_showText);
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

    private void OnHealthChanged(ushort currentHealth)
    {
        _healthTxt = currentHealth.ToString();

        if (_TMPro != null)
            StartCoroutine(_showText);
    }

    private IEnumerator ShowText()
    {
        _TMPro.text = _healthTxt;
        _characterView.transform.localScale = _characterView.transform.localScale * _damagedScale;

        yield return new WaitForSeconds(_showTextTime);

        _characterView.transform.localScale = _characterView.transform.localScale / _damagedScale;
        _TMPro.text = "";
    }
}