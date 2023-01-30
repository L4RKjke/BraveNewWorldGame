using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class AtackState : State
{
    private readonly int _critÑhance = 10;
    private readonly float _critMultiplier = 1.5f;

    public float FirstDelaySpread => Random.Range(0.1f, 0.25f);

    public UnityAction AtackCompleted;

    public UnityAction<UnityAction> AtackStarted;

    protected ushort Damage => GetDamage();

    protected abstract void CompleteAtack();

    protected IEnumerator LaunchActackCoroutine(float atackDelay)
    {
        var spread = Random.Range(0, 0.3f);

        yield return new WaitForSeconds(atackDelay + spread);

        if (enabled == true)
            AtackStarted?.Invoke(CompleteAtack); ;
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
