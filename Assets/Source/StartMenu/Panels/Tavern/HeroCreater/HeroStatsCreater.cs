using UnityEngine;

public abstract class HeroStatsCreater : ScriptableObject
{
    [SerializeField] private int[] _minMaxAttack;
    [SerializeField] private int[] _minMaxDefense;
    [SerializeField] private int[] _minMaxHealth;
    [SerializeField] private int[] _minMaxMagic;
    [SerializeField] private int _maxStatsPoint = 50;
    [SerializeField] private int _pointToDefense = 2;
    [SerializeField] private int _healthToPoint = 10;

    private int _leftStatsPoint;

    protected int PointToDefense => _pointToDefense;
    protected int HealthToPoint => _healthToPoint;

    public void CreateStats(CharacterStats characterStats)
    {
        _leftStatsPoint = _maxStatsPoint;
        int attack = Random.Range(_minMaxAttack[0], _minMaxAttack[1] + 1);
        int defense = Random.Range(_minMaxDefense[0], _minMaxDefense[1] + 1);
        int health = Random.Range(_minMaxHealth[0], _minMaxHealth[1] + 1);
        int magic = Random.Range(_minMaxMagic[0], _minMaxMagic[1] + 1);
        _leftStatsPoint -= attack + defense * _pointToDefense + health / _healthToPoint + magic;
        characterStats.SetBaseStats(attack, defense, health, magic);

        DistributeLeftStats(_leftStatsPoint, characterStats);
    }

    protected abstract void DistributeLeftStats(int leftStats, CharacterStats characterStats);
}
