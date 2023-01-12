using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Recruit))]

public class RecruitAtackState : AtackState
{
    [SerializeField] private HeroAnimatorContreller _controller;

    private Recruit _recruit;

    private readonly int _passiveSkillChance = 15;

    public UnityAction AtackStarted;

    private void OnEnable()
    {
        _recruit = GetComponent<Recruit>();
        StartCoroutine("LaunchActack");

        _controller.AtackCompleted += OnAtackComplete;
    }

    private void OnDisable()
    {
        StopCoroutine("LaunchActack");

        if (_controller != null)
        {
            _controller.AtackCompleted -= OnAtackComplete;
        }
    }

    protected override void StartAtack()
    {
        AtackStarted?.Invoke();
    }


    private void OnAtackComplete()
    {
        var minParcent = 0;
        var maxPercent = 100;
        var randomNumber = Random.Range(minParcent, maxPercent);

        if (randomNumber < _passiveSkillChance)
            _recruit.UsePassiveSkill();
        else
            if (_recruit.Weapon == null)
            _recruit.Atack();
        else
            _recruit.Weapon.UseWeapon();
    }
}
