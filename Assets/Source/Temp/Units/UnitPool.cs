using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class UnitPool : MonoBehaviour
{
    private List<Fighter> _fighters = new List<Fighter> { };

    public UnityAction<FighterType> UnitDied;

    private void OnDisable()
    {
        for (int i = 0; i < _fighters.Count; i++)
        {
            _fighters[i].Health.Died -= OnUnitDied;
        }
    }

    public int GetLength(FighterType fighterType)
    {
        return _fighters.Where(fighter => fighter.MyType == fighterType).Count();
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
        fighter.Health.Died += OnUnitDied;
    }

    public Fighter GetById(int id, FighterType type)
    {
        var fighters = _fighters.Where(fighter => fighter.MyType == type).ToArray();

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
            if (fighter.MyType == fighterType)
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
        Destroy(fighter.transform.parent.gameObject);
        RemoveFighter(fighter);
        UnitDied?.Invoke(fighter.MyType);
    }
}