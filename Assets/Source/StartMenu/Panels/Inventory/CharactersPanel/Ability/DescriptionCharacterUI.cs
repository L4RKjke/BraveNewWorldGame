using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DescriptionCharacterUI : AbilitiesUI
{
    [SerializeField] private TMP_Text _textClass;
    [SerializeField] private List<string> _descriptionPath;

    public override void UpdateAbility(int id, Ability ability)
    {
        GameObject abilityObject = Container.transform.GetChild(id).gameObject;
        abilityObject.GetComponent<TMP_Text>().text = ability.Name + " - " + ability.Description;
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
