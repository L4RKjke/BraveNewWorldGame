using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroPassiveSkills : ScriptableObject
{
    [SerializeField] private List<Ability> _abilities;

    public void SetSkills(Recruit recruit, CharacterData characterData)
    {
        int count = 2;
        int addedAbility = -1;
        int random = -1;
        CharacterAbilities abilities = recruit.transform.gameObject.GetComponent<CharacterAbilities>();

        for (int i = 0; i < count; i++)
        {
            while(random == addedAbility)
            {
                random = Random.Range(0, _abilities.Count);
            }

            _abilities[random].SetAbility(recruit);
            characterData.AddSkillId(random, i);
            addedAbility = random;
            //abilities.AddAbility(_abilities[random]);
        }
    }

    public Ability GetSkill(int id)
    {
        return _abilities[id];
    }
}
