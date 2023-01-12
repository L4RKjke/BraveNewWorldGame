using System.Collections;
using UnityEngine;

public class Priest : Recruit
{
    [SerializeField] private GameObject _passiveLighting;
    [SerializeField] private GameObject _healPart;

    private float _currentHealingTime = 0;

    private readonly float _healDelay = 0.2f;
    private readonly float _maxHealingTime = 30;

    /// ������������ ����, ������ ���� ������� ��� ����� �� ����.

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
        var randomMate = Units.GetById(GetRandom(), FighterType.Recruit);

        randomMate.Heal();
        _healPart.SetActive(true);
        _healPart.GetComponent<ParticleSystem>().Play();
        _healPart.GetComponent<HealPartMover>().Init(randomMate);
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
