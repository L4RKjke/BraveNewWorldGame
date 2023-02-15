using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroNamesCreater : ScriptableObject
{
    [SerializeField] private List<string> _heroNames;

    public void SetName(CharacterStats characterStats)
    {
        string name = Lean.Localization.LeanLocalization.GetTranslationText(_heroNames[Random.Range(0, _heroNames.Count)]);
        characterStats.SetName(name);
    }
}
