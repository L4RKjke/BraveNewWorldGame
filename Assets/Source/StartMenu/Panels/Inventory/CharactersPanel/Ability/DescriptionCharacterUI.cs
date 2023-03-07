using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DescriptionCharacterUI : AbilitiesUI
{
    [SerializeField] private TMP_Text _textClass;
    [SerializeField] private List<string> _descriptionPath;

    public override void UpdateAbility(Ability[] ability)
    {
        if (Container.transform.childCount > ability.Length)
        {
            int difference = Container.transform.childCount - ability.Length;

            for (int i = 0; i < difference; i++)
            {
                Destroy(Container.transform.GetChild(Container.transform.childCount - 1).gameObject);
            }
        }
        else if (Container.transform.childCount < ability.Length)
        {
            int difference = ability.Length - Container.transform.childCount;

            for (int i = 0; i < difference; i++)
            {
                AddDescription(Container.transform.childCount);
            }
        }

        for (int i = 0; i < ability.Length; i++)
        {
            GameObject abilityObject = Container.transform.GetChild(i).gameObject;
            abilityObject.GetComponent<TMP_Text>().text = ability[i].Name + " - " + ability[i].Description;
        }
    }

    public void SetDescriptionClass(GameObject character)
    {
        ClassType classType = character.transform.GetChild(1).GetComponent<Recruit>().Class;

        switch (classType)
        {
            case ClassType.Wizzard:
                UpdateClassDescription(Lean.Localization.LeanLocalization.GetTranslationText(_descriptionPath[0]));
                break;
            case ClassType.Warrior:
                UpdateClassDescription(Lean.Localization.LeanLocalization.GetTranslationText(_descriptionPath[1]));
                break;
            case ClassType.Priest:
                UpdateClassDescription(Lean.Localization.LeanLocalization.GetTranslationText(_descriptionPath[2]));
                break;
        }
    }

    private void UpdateClassDescription(string description)
    {
        _textClass.text = description;
    }
}
