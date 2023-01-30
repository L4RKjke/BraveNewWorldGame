using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class AtackState : State
{
    private readonly int _critÑhance = 10;
    private readonly float _critMultiplier = 1.5f;

    public float FirstDelaySpread => Random.Range(0, 0.2f);

    public UnityAction<UnityAction> AtackStarted;

    protected ushort Damage => GetDamage();

    public void Atack()
    {
        AtackStarted?.Invoke(CompleteAtack);
    }

    protected abstract void CompleteAtack();

    protected IEnumerator LaunchActack(float atackDelay)
    {
        var spread = Random.Range(-0.2f, 0.2f);

        yield return new WaitForSeconds(atackDelay + spread);

        if (this.enabled == true)
            Atack();
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
