using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Fireball : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;

    private int _damage;

    private readonly float _speed = 3;
    private readonly float _lifetime = 3;
    private FighterType _targetType;


    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * _speed;
        StartCoroutine(LifeTimeCorutine());
    }

    public void Init(FighterType targetType, int damage)
    {
        _targetType = targetType;
        _damage = damage;
    }

    public void IncreaseDamage(int damage)
    {
        _damage += damage;
    }

    private void OnDisable()
    {
        StopCoroutine(LifeTimeCorutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fighter target))
        {
            if (_targetType == target.Type)
            {
                target.Health.TakeDamage(_damage, Health.DamageType.Magical);
                Instantiate(_hitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator LifeTimeCorutine()
    {
        yield return new WaitForSeconds(_lifetime);
        Destroy(gameObject);
    }
}