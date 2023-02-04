using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class UnitPool : MonoBehaviour
{
    private List<Fighter> _fighters = new List<Fighter> { };

    public UnityAction<FighterType> UnitDied;
    public UnityAction<FighterType> SquadLose;

    private void OnDisable()
    {
        for (int i = 0; i < _fighters.Count; i++)
        {
            _fighters[i].Health.Died -= OnUnitDied;
        }
    }

    public int GetLength(FighterType fighterType)
    {
        return _fighters.Where(fighter => fighter.Type == fighterType).Count();
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
        var fighters = _fighters.Where(fighter => fighter.Type == type).ToArray();

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
            if (fighter.Type == fighterType)
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

    public void CleanPool()
    {
        for (int i = 0; i < GetLength(); i++)
        {
            if (GetById(i).RootModel.transform.parent.TryGetComponent(out DragAndDrop model))
                Destroy(model.gameObject);
            else
                Destroy(GetById(i).RootModel.gameObject);
        }

        _fighters.Clear();
    }

    public int GetHorizontalIndex(Fighter unit)
    {
        var result = _fighters.
            OrderBy(fighter => fighter.transform.position.y).
            Select(fighter => fighter).
            ToList().IndexOf(unit);

        return result;
    }

    private void OnUnitDied(Fighter fighter)
    {
        ///проверить мб сначало удалить, потом дестроить
        Destroy(fighter.transform.parent.gameObject);
        RemoveFighter(fighter);
        UnitDied?.Invoke(fighter.Type);

        if (GetLength(fighter.Type) == 0)
            SquadLose?.Invoke(fighter.Type);
    }
}