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

    protected abstract void CompleteAtack();

    protected abstract void StartAtack();

    protected IEnumerator LaunchActack(float atackDelay)
    {
        var spread = Random.Range(-0.1f, 0.1f);

        while (true)
        {
            StartAtack();
            yield return new WaitForSeconds(atackDelay + spread);
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
