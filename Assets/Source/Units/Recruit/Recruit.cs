using UnityEngine;

public abstract class Recruit: Fighter
{
    private Weapon _weapon;

    public Weapon Weapon => _weapon;

    public int Level {  get; private set; }

    public abstract void Atack();

    public abstract void UsePassiveSkill();

    private void OnEnable()
    {
        if (transform.GetChild(0).TryGetComponent(out Weapon weapon))
        {
            _weapon = weapon;
        }
    }

    private void Update()
    {
        ///Переделать этот бред
        if (CurrentTarget != null)

        if (CurrentTarget.transform.position.x > transform.position.x)
            transform.parent.localScale = DefoaltScale;
        else
            transform.parent.localScale = InvertedScale;
    }
}
