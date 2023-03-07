using System.Collections.Generic;
using UnityEngine;

public abstract class HeroPassiveSkills : ScriptableObject
{
    [SerializeField] private List<Ability> _abilities;

    public void SetSkills(Recruit recruit, CharacterData characterData)
    {
        int count = 3;
        List<int> addedAbility = new List<int>();
        int random = -1;
        random = Random.Range(0, _abilities.Count);

        for (int i = 0; i < count; i++)
        {
            while (HaveSameAbility(addedAbility, random))
            {
                random = Random.Range(0, _abilities.Count);
            }

            _abilities[random].SetAbility(recruit, _abilities[random].NamePath, _abilities[random].DescriptionPath);
            characterData.AddSkillId(random, i);
            addedAbility.Add(random);
        }
    }

    public Ability GetSkill(int id)
    {
        return _abilities[id];
    }

    private bool HaveSameAbility(List<int> added, int newAbility)
    {
        for (int i = 0; i < added.Count; i++)
        {
            if (added[i] == newAbility)
                return true;
        }

        return false;
    }
}
