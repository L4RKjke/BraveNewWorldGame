using UnityEngine;
using UnityEngine.Events;

public abstract class Recruit : Fighter
{
    private int _magicPower = 50; //поменять на 0

    private readonly int _minMagicPower = 0;
    private readonly int _maxMagicPower = 100;
    private readonly int _maxPercent = 100;
    private readonly int _minPercent = 0;

    public int MagicPower => _magicPower;

    public void Init(FighterType type, FighterType enemyType, UnitPool units, ushort damage, int health, int magicPower = 0)
    {
        base.Init(type, enemyType, units, damage, health);

        if (magicPower > _maxMagicPower)
            magicPower = _maxMagicPower;

        if (magicPower < _minMagicPower)
            magicPower = _minMagicPower;

        _magicPower = magicPower;
    }

    protected void ChooseAtack(UnityAction defaultAtack, UnityAction AdvancedAtack)
    {
        var randomNumber = Random.Range(_minPercent, _maxPercent);

        if (randomNumber < _magicPower)
            AdvancedAtack();

        else
            defaultAtack();
    }

    protected abstract void OnAdvancedAtack();

    protected abstract void OnDefaultAtack();
}
