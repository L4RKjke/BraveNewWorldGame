using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Fireball : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;

    private ushort _damage;

    private readonly float _speed = 3;
    private readonly float _lifetime = 3;
    private FighterType _targetType;


    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * _speed;
        StartCoroutine(LifeTimeCorutine());
    }

    public void Init(FighterType targetType, ushort damage)
    {
        _targetType = targetType;
        _damage = damage;
    }

    public void IncreaseDamage(ushort damage)
    {
        _damage += damage;
    }

    private void OnDestroy()
    {
        Instantiate(_hitEffect, transform.position, Quaternion.identity);
        StopCoroutine(LifeTimeCorutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fighter target))
        {
            if (_targetType == target.MyType)
            {
                target.TakeDamage(_damage);
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
