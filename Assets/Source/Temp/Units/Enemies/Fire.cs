using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Fire : MonoBehaviour
{
    private Coroutine _fireRoutine;
    private ParticleSystem _fireParticles;
    private float _playTime = 0;
    private float _damageDelay = 0.1f;
    private float _damageScaler;
    private Fighter _target;
    private Transform _firePoint;
    private List<Fighter> _targets = new List<Fighter>() { };

    private void Start()
    {
        _targets.Clear();
        _fireParticles = GetComponent<ParticleSystem>();
        _playTime = _fireParticles.main.duration;
        _damageScaler = _playTime / _damageDelay;
    }

    private void OnDisable()
    {
        if (_fireRoutine != null)
            StopCoroutine(_fireRoutine);
    }

    private void Update()
    {
        RorateFire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Recruit unit))
        {
            _targets.Add(unit);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Recruit unit))
        {
             _targets.Remove(unit);
        }
    }

    public void StartFire(int damage, Fighter target, Transform firePoint)
    {
        _target = target;
        _firePoint = firePoint;

        _fireParticles.Play();

        if (_fireRoutine != null)
            StopCoroutine(_fireRoutine);

        _fireRoutine = StartCoroutine(Burn(damage));
    }

    private IEnumerator Burn(int damage)
    {
        var fireDamage = Mathf.FloorToInt(damage / _damageScaler);

        while (_fireParticles.isPlaying)
        {
            yield return new WaitForSeconds(_damageDelay);

            for (int i = 0; i < _targets.Count; i++)
            {
                var target = _targets[i];

                if (target != null)
                    target.Health.TakeDamage(fireDamage, Health.DamageType.Magical);
            }
        }
    }

    private void RorateFire()
    {
        if (_fireParticles.isPlaying && _target != null && _firePoint != null)
        {
            if (_target.transform.parent.position.x - _firePoint.position.x < 0)
                transform.parent.rotation = Quaternion.Euler(0, 0, GetAngle(_target, _firePoint) - 180);
            else
                transform.parent.rotation = Quaternion.Euler(0, 0, GetAngle(_target, _firePoint));
        }
    }

    private float GetAngle(Fighter currentTarget, Transform firePoint) => (180 / Mathf.PI) *
        Mathf.Atan((currentTarget.transform.position.y - firePoint.position.y) / (currentTarget.transform.position.x - firePoint.position.x));
}