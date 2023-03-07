using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    private List<Ability> _abilities = new List<Ability>();

    public int AbilitiesCount => _abilities.Count;

    public void AddAbility(Ability ability)
    {
        _abilities.Add(ability);
    }    

    public Ability GetAbility(int id)
    {
        return _abilities[id];
    }
}
