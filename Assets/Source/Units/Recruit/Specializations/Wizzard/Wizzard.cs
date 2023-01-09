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

    public UnityAction AtackCompleted;

    /*Переделать на на наносит урон, равный проценты от хп (процент можно увеличивать от предметов или праченной абилки)*/
    /*Добавить предметы, которые блокируют определенный тип урона или снижаеют его*/
    private readonly ushort _passiveAbilityDamage = 30;

    public override void Atack()
    {
        StartCoroutine(WaitAnimation(OnDefaultAtack));
    }

    public override void UseAdvancedAtack()
    {
        StartCoroutine(WaitAnimation(OnAdvancedAtack));
    }

    public override void UseUltimate()
    {
        CurrentTarget.TakeDamage(Damage);
    }

    private void OnDefaultAtack()
    {
        if (CurrentTarget != null)
        {
            if (CurrentTarget.transform.position.x > transform.position.x)
                InstantiateBullet(GetAngle());
            else
                InstantiateBullet(GetAngle() + 180);
        }
    }

    private void OnAdvancedAtack()
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
        Instantiate(_fireball, _firePoint.position, Quaternion.Euler(new Vector3(0, 0, angel)));
    }

    private float GetAngle() => (180 / Mathf.PI) *
        Mathf.Atan((CurrentTarget.transform.position.y - transform.position.y) / (CurrentTarget.transform.position.x - transform.position.x));

    private IEnumerator WaitAnimation(Action callback)
    {
        yield return new WaitForSeconds(0.7f);

        callback();
    }
}