using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public abstract class AtackState : State
{
    [SerializeField] private AnimationCotroller _animationController;

    private readonly int _critСhance = 10;
    private readonly float _critMultiplier = 1.5f;

    protected AnimationCotroller AnimationController => _animationController;

    public float FirstDelaySpread => Random.Range(0.1f, 0.25f);

    public UnityAction AtackStarted;

    protected ushort Damage => GetDamage();

    protected abstract void StartAtack();

    protected abstract void CompleteAtack();

    protected IEnumerator LaunchAtack(float atackDelay)
    {
        yield return new WaitForSeconds(atackDelay);

        StartAtack();
    }

    /// Перенести это все в воина
    private ushort GetDamage()
    {
        var minParcent = 0;
        var maxPercent = 100;
        var randomNumber = Random.Range(minParcent, maxPercent);

        if (randomNumber < _critСhance)
            return (ushort)(CurrentFighter.Damage * _critMultiplier);
        else
            return (ushort)(CurrentFighter.Damage);
    }
}
