using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Fireball : MonoBehaviour
{
    private ushort _bulletDamage = 4;

    private readonly float _speed = 2;
    private readonly float _lifetime = 5;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * _speed;
        StartCoroutine(LifeTimeCorutine());
    }

    public void IncreaseDamage(ushort damage)
    {
        _bulletDamage += damage;
    }

    private void OnDestroy()
    {
        StopCoroutine(LifeTimeCorutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy target))
        {
            target.TakeDamage(_bulletDamage);
            Destroy(gameObject);
        }
    }

    private IEnumerator LifeTimeCorutine()
    {
        yield return new WaitForSeconds(_lifetime);
        Destroy(gameObject);
    }
}
