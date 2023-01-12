using System.Collections;
using UnityEngine;

public class Priest : Recruit
{
    [SerializeField] private GameObject _passiveLighting;

    private float _currentHealingTime = 0;

    private readonly float _healDelay = 0.2f;
    private readonly float _maxHealingTime = 30;

    /// Божественная кара, просто удар молнией или лучом по цели.

    public override void Atack()
    {
        if (CurrentTarget != null)
            CurrentTarget.TakeDamage(Damage);
        _passiveLighting.SetActive(true);
        _passiveLighting.GetComponent<ParticleSystem>().Play();
        _passiveLighting.transform.position = new Vector2(CurrentTarget.transform.position.x, CurrentTarget.transform.position.y);
    }

    private void OnDisable()
    {
        StopCoroutine(StartHealing());
    }

    public override void UsePassiveSkill()
    {
        Units.GetById(GetRandom(), FighterType.Recruit).Heal();
    }

    private IEnumerator StartHealing()
    {
        while (true)
        {
            Units.GetById(GetRandom(), FighterType.Recruit).AddHealthPoint();
            _currentHealingTime += _healDelay;

            if (_currentHealingTime >= _maxHealingTime)
                yield break;

            yield return new WaitForSeconds(_healDelay);
        }
    }

    private int GetRandom() => Random.Range(0, Units.GetLength(FighterType.Recruit));
}
