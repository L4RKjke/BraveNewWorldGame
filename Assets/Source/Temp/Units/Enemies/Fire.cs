using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class Fire : MonoBehaviour
{
    private Coroutine _fireRoutine;
    private ParticleSystem _fireParticles;
    private float _playTime = 0;
    private float _damageDelay = 0.1f;
    private float _damageScaler;

    private void Start()
    {
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
        
    }

    public void StartFire(int damage, Fighter target, Transform firePoint)
    {
        transform.parent.rotation = Quaternion.Euler(GetAngle(target, firePoint), 90, 0);

        _fireParticles.Play();

        if (_fireRoutine != null)
            StopCoroutine(_fireRoutine);

        _fireRoutine = StartCoroutine(Burn(damage, target));
    }

    private IEnumerator Burn(int damage, Fighter target)
    {
        var fireDamage = Mathf.FloorToInt(damage / _damageScaler);

        while (_fireParticles.isPlaying)
        {
            yield return new WaitForSeconds(_damageDelay);

            if (target != null)
                target.Health.TakeDamage(fireDamage);
        }    
    }

    private float GetAngle(Fighter currentTarget, Transform firePoint) => (180 / Mathf.PI) *
        Mathf.Atan((currentTarget.transform.position.y - firePoint.position.y) / (currentTarget.transform.position.x - firePoint.position.x));
}
