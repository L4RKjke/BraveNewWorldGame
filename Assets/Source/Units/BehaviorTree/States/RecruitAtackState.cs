using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Recruit))]

public class RecruitAtackState : AtackState
{
    private Recruit _recruit;

    private readonly int _passiveSkillChance = 20;

    public UnityAction RecruitAtacked;

    private void OnEnable()
    {
        _recruit = GetComponent<Recruit>();
        StartCoroutine(LaunchActack());
    }

    private void OnDisable()
    {
        StopCoroutine(LaunchActack());
    }

    override public void Atack()
    {
        var minParcent = 0;
        var maxPercent = 100;
        var randomNumber = Random.Range(minParcent, maxPercent);

        RecruitAtacked?.Invoke();

        if (randomNumber < _passiveSkillChance)
            _recruit.UseAdvancedAtack();
        else
            if (_recruit.Weapon == null)
                _recruit.Atack();
            else
                _recruit.Weapon.UseWeapon();
    }
}
