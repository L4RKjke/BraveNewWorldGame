using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Wizzard : Recruit
{
    [SerializeField] private Fireball _fireball;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _electricity;

    public Fireball Fireball => _fireball;

    /*Переделать на на наносит урон, равный проценты от хп (процент можно увеличивать от предметов или праченной абилки)*/
    /*Добавить предметы, которые блокируют определенный тип урона или снижаеют его*/
    private readonly ushort _passiveAbilityDamage = 30;

    public override void Atack()
    {
        if (CurrentTarget != null)
        {
            if (CurrentTarget.transform.position.x > transform.position.x)
                InstantiateBullet(GetAngle());
            else
                InstantiateBullet(GetAngle() + 180);
        }
    }

    public override void UsePassiveSkill()
    {
        if (CurrentTarget != null)
        {
            CurrentTarget.TakeDamage(_passiveAbilityDamage);
            _electricity.SetActive(true);
            _electricity.GetComponent<ParticleSystem>().Play();
            _electricity.transform.position = new Vector2(CurrentTarget.transform.position.x, CurrentTarget.transform.position.y + 9);
        }
    }

    private void InstantiateBullet(float angel)
    {
        Instantiate(_fireball, transform.position, Quaternion.Euler(new Vector3(0, 0, angel)));
    }

    private float GetAngle() => (180 / Mathf.PI) *
        Mathf.Atan((CurrentTarget.transform.position.y - transform.position.y) / (CurrentTarget.transform.position.x - transform.position.x));
}