using System.Collections;
using UnityEngine;

public abstract class AtackState : State
{
    [SerializeField] private AnimationCotroller _controller;

    private readonly int _critÑhance = 10;
    private readonly float _critMultiplier = 1.5f;

    protected AnimationCotroller Controller => _controller;

    protected readonly string Launch  = "LaunchActack";

    protected ushort Damage => GetDamage();

    private void OnEnable()
    {
        StartCoroutine(Launch);

        Controller.AtackCompleted += CompleteAtack;
    }

    private void OnDisable()
    {
        StopCoroutine(Launch);

        if (Controller != null)
        {
            Controller.AtackCompleted -= CompleteAtack;
        }
    }

    protected abstract void CompleteAtack();

    protected abstract void StartAtack();

    protected IEnumerator LaunchActack()
    {
        while (true)
        {
            StartAtack();
            yield return new WaitForSeconds(CurrentFighter.AtackDelay);
        }
    }

    private ushort GetDamage()
    {
        var minParcent = 0;
        var maxPercent = 100;
        var randomNumber = Random.Range(minParcent, maxPercent);

        if (randomNumber < _critÑhance)
            return (ushort)(CurrentFighter.Damage * _critMultiplier);
        else
            return (ushort)(CurrentFighter.Damage);
    }
}
