using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitPool : MonoBehaviour
{
    private List<Fighter> _fighters = new List<Fighter> { };

    private void OnDisable()
    {
        for (int i = 0; i < _fighters.Count; i++)
        {
            _fighters[i].Died -= OnUnitDied;
        }
    }

    public int GetLength(FighterType fighterType)
    {
        return _fighters.Where(fighter => fighter.RecruitType == fighterType).Count();
    }

    public int GetLength()
    {
        return _fighters.Count;
    }

    public void RemoveFighter(Fighter fighter)
    {
        _fighters.Remove(fighter);
    }

    public void AddNewFighter(Fighter fighter)
    {
        _fighters.Add(fighter);
        fighter.Died += OnUnitDied;
    }

    public Fighter GetById(int id, FighterType type)
    {
        var fighters = _fighters.Where(fighter => fighter.RecruitType == type).ToArray();

       return fighters[id];
    }

    public Fighter GetById(int id)
    {
        if (id <= _fighters.Count && id >= 0)
            return _fighters[id];
        else 
            return null;
    }

    public Fighter GenerateClosestFighter(FighterType fighterType, Vector2 position) 
    {
        Fighter target = null;
        float minDistance = Mathf.Infinity;

        foreach (var fighter in _fighters)
        {
            if (fighter.RecruitType == fighterType)
            {
                float distance = Vector2.Distance(fighter.transform.position, position);

                if (distance < minDistance)
                {
                    target = fighter;
                    minDistance = distance;
                }
            }
        }

        return target;
    }

    private void OnUnitDied(Fighter fighter)
    {
        RemoveFighter(fighter);
    }
}