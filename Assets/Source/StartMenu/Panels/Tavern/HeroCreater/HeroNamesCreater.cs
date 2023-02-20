using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroNamesCreater : ScriptableObject
{
    [SerializeField] private List<string> _heroNames;

    public void SetName(CharacterStats characterStats, CharacterData characterData)
    {
        int random = Random.Range(0, _heroNames.Count);
        string name = Lean.Localization.LeanLocalization.GetTranslationText(_heroNames[random]);
        characterStats.SetName(name);
        characterData.SetName(_heroNames[random]);
    }
}
