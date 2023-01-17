using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Recruit))]

public class RecruitAtackState : AtackState
{
    private Recruit _recruit;

    private readonly int _passiveSkillChance = 25;

    public UnityAction RangeAtackStarted;

    private void OnEnable()
    {
        _recruit = GetComponent<Recruit>();
        StartCoroutine(Launch);

        Controller.AtackCompleted += CompleteAtack;
    }

    private void OnDisable()
    {
        StopCoroutine(Launch);

        if (Controller != null)
        {
            Controller.AtackCompleted -= CompleteAtack;
        }
    }

    protected override void StartAtack()
    {
        RangeAtackStarted?.Invoke();
    }


    protected override void CompleteAtack()
    {
        var minParcent = 0;
        var maxPercent = 100;
        var randomNumber = Random.Range(minParcent, maxPercent);

        if (randomNumber < _passiveSkillChance)
            _recruit.UsePassiveSkill();
        else
            _recruit.Atack();
    }
}