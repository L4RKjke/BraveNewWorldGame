using UnityEngine;
// каждый удар увеличивает здоровье на <_damageFactor>% от значения нанесенного урона
public class BloodlustAbility : DamageAbility
{
    private readonly float _damageFactor = 0.25f;
    private int _damageTaken = 0;

    private void Start()
    {
        Fighter.Health.Damaged += OnHealthChanged;
    }

    private void OnDisable()
    {
        Fighter.Health.Damaged -= OnHealthChanged;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        BloodlustAbility ability = recruit.gameObject.AddComponent<BloodlustAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        var healValue = Mathf.FloorToInt(_damageTaken * _damageFactor); 

        Fighter.Health.Heal(healValue);       
    }

    private void OnHealthChanged(int damage)
    {
        _damageTaken = damage;
        ActivateAbility();
    }
}
