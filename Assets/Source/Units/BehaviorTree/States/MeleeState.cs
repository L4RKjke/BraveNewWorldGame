using UnityEngine;
using UnityEngine.Events;

public class MeleeState : AtackState
{
    public UnityAction MelleeAtackStarted;

    private void OnEnable()
    {
        StartCoroutine(Launch);
        Controller.AtackCompleted += CompleteAtack;
    }

    private void OnDisable()
    {
        StopCoroutine(Launch);
        Controller.AtackCompleted -= CompleteAtack;
    }

    override protected void StartAtack()
    {
        MelleeAtackStarted?.Invoke();
    }

    override protected void CompleteAtack()
    {
        ///?? переделать
        if (TryGetComponent(out Recruit recruit))
        {
            if (recruit.Weapon == null)
                recruit.CurrentTarget.TakeDamage(recruit.Damage);
            else
            {
                recruit.CurrentTarget.TakeDamage((ushort)(recruit.Damage + recruit.Weapon.Damage));
            }

        } 
        else
        {
            Fighter.CurrentTarget.TakeDamage(Fighter.Damage);
        }
    }
}
