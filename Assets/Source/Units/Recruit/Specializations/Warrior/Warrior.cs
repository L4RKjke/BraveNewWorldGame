using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Warrior : Recruit
{
/*    private ushort _currentDamage;

    private readonly ushort _damageMultiplier = 2;*/

    /*    private void Start()
        {
            _currentDamage = Damage;
        }

        public override void Atack()
        {
            if (CurrentTarget != null)
                CurrentTarget.TakeDamage(_currentDamage);
        }

        public override void UsePassiveSkill()
        {
            _currentDamage *= _damageMultiplier;
        }*/

    public override void Atack()
    {
/*        if (CurrentTarget != null)
        {
            if (CurrentTarget.transform.position.x > transform.position.x)
                InstantiateBullet(GetAngle());
            else
                InstantiateBullet(GetAngle() + 180);
        }*/
    }

    public override void UsePassiveSkill()
    {
/*        if (CurrentTarget != null)
        {
            CurrentTarget.TakeDamage(_passiveAbilityDamage);
            _electricity.SetActive(true);
            _electricity.GetComponent<ParticleSystem>().Play();
            _electricity.transform.position = new Vector2(CurrentTarget.transform.position.x, CurrentTarget.transform.position.y + 9);
        }*/
    }
}
