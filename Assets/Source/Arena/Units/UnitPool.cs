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
        var numberOfUnitsOfType = 0;

        for (int i = 0; i < _fighters.Count; i++)
        {
            if (_fighters[i].Type == fighterType)
                numberOfUnitsOfType++;
        }

        return numberOfUnitsOfType;
    }

    public int GetLength()
    {
        return _fighters.Count;
    }

    public void RemoveFighter(Fighter fighter)
    {
        _fighters.Remove(fighter);
        fighter.Health.Died -= OnUnitDied;
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
        Destroy(fighter.transform.parent.gameObject);
        RemoveFighter(fighter);
        UnitDied?.Invoke(fighter.Type);
    }
}