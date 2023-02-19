using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbilitiesUI : RenderUI
{
    private int _abilitiesCount = 0;

    public void Init(int count)
    {
        _abilitiesCount = count;
        AddGraphics();
    }

    public virtual void UpdateAbility(int id, Ability ability)
    {
        GameObject abilityObject = Container.transform.GetChild(id).gameObject;
        abilityObject.GetComponent<TMP_Text>().text = ability.Name;
        abilityObject.GetComponent<AbilityShower>().Init(ability.Description);
    }

    protected override void AddGraphics()
    {
        for (int i = 0; i < _abilitiesCount; i++)
        {
            GameObject newAbility = Instantiate(Content, Container.transform) as GameObject;
            newAbility.name = i.ToString();
        }
    }
}
