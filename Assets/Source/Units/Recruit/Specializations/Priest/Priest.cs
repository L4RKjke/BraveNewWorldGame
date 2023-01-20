using System.Collections;
using UnityEngine;

public class Priest : Recruit, IRangeAtacker
{
    [SerializeField] private GameObject _healPart;

    public void Shoot(ushort damage)
    {
        var mate = GetWounded();
        mate.Heal();

        _healPart.SetActive(true);
        _healPart.GetComponent<ParticleSystem>().Play();
        _healPart.GetComponent<HealPartMover>().Init(mate);
    }

    private Fighter GetWounded()
    {
        float minHealth = Mathf.Infinity;
        Fighter fighter = null;

        for (int i = 0; i < Units.GetLength(FighterType.Recruit); i++)
        {
            var unit = Units.GetById(i, FighterType.Recruit);

            if (unit.Health < minHealth)
            {
                fighter = unit;
                minHealth = Units.GetById(i, FighterType.Recruit).Health;
            }
        }
        return fighter;
    }
}
