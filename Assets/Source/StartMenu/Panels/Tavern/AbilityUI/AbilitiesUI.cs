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

    public virtual void UpdateAbility(Ability[] ability)
    {
        for (int i = 0; i < ability.Length; i++)
        {
            GameObject abilityObject = Container.transform.GetChild(i).gameObject;
            abilityObject.GetComponent<TMP_Text>().text = ability[i].Name;
            abilityObject.GetComponent<AbilityShower>().Init(ability[i].Description);
        }
    }

    protected override void AddGraphics()
    {
        for (int i = 0; i < _abilitiesCount; i++)
        {
            AddDescription(i);
        }
    }

    protected void AddDescription(int id)
    {
        GameObject newAbility = Instantiate(Content, Container.transform) as GameObject;
        newAbility.name = id.ToString();
    }
}
