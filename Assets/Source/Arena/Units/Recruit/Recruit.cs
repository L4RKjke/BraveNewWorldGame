using UnityEngine;
using UnityEngine.Events;

public abstract class Recruit : Fighter
{
    [SerializeField] private ClassType _class;

    private int _magicPower = 0;
    private readonly int _maxPercent = 100;
    private readonly int _minPercent = 0;
    private readonly int _abilityChance = 30;

    public ClassType Class => _class;

    public int MagicPower => _magicPower;

    public void Init(FighterType type, FighterType enemyType, UnitPool units, int damage, int health, int magicPower = 0, int defense = 0)
    {
        base.Init(type, enemyType, units, damage, health);
        Health.Init(health, defense);
        _magicPower = magicPower;
    }

    protected void ChooseAtack(UnityAction defaultAtack, UnityAction AdvancedAtack)
    {
        var randomNumber = Random.Range(_minPercent, _maxPercent);

        if (randomNumber < _abilityChance)
            AdvancedAtack();

        else
            defaultAtack();
    }

    protected abstract void OnAdvancedAtack();

    protected abstract void OnDefaultAtack();
}
