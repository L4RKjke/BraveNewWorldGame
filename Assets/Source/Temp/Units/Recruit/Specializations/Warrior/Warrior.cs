using UnityEngine;

public class Warrior : Recruit
{
    [SerializeField] private ParticleSystem _damageParticle;

    public override void Atack(int damage)
    {
        ChooseAtack(OnDefaultAtack, OnAdvancedAtack);
    }

    protected override void OnDefaultAtack()
    {
        base.Atack(Damage);
    }

    override protected void OnAdvancedAtack()
    {
        base.Atack(GetAdvancedDamage());

        if (CurrentTarget != null)
        {
            _damageParticle.transform.position = CurrentTarget.transform.position;
            _damageParticle.Play();
        }
    }

    private int GetAdvancedDamage() => (Damage + MagicPower);
}