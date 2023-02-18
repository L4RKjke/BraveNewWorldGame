using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TavernSaveLoad : MonoBehaviour, BinarrySaveLoad
{
    [SerializeField] private TavernUI _tavernUI;
    [SerializeField] private List<HeroAppearanceCreater> _heroAppearanceCreater;
    [SerializeField] private List<HeroPassiveSkills> _heroPassiveSkills;

    private List<CharacterData> _charactersData = new List<CharacterData>();

    public void AddData(CharacterData characterData)
    {
        _charactersData.Add(characterData);
    }

    public void ClearData()
    {
        _charactersData.Clear();
    }

    public void Load()
    {
        List<CharacterData> charactersData = BinarySavingSystem.LoadTavern();
        GameObject buttonObject;
        GameObject character;

        for (int i = 0; i < charactersData.Count; i++)
        {
            buttonObject = _tavernUI.AddButton(i);
            StatsUI statsUI = buttonObject.GetComponentInChildren<StatsUI>();
            statsUI.UpdateName(Lean.Localization.LeanLocalization.GetTranslationText(_charactersData[i].Name));
            statsUI.UpdateAllStats(charactersData[i].Attack, charactersData[i].Defense, charactersData[i].Health, charactersData[i].Magic);
            character = buttonObject.GetComponentInChildren<TavernCharactersUI>().PointToCreate.transform.GetChild(0).gameObject;

            if (charactersData[i].Class == -1)
            {
                Destroy(character);
                Button temp = buttonObject.GetComponentInChildren<Button>();
                temp.interactable = false;
                temp.GetComponentInChildren<TMP_Text>().text = Lean.Localization.LeanLocalization.GetTranslationText("Common/Sold");
                buttonObject.transform.GetChild(buttonObject.transform.childCount - 1).gameObject.SetActive(true);
            }
            else
            {
                HeroAppearanceCreater heroAppearanceCreater = _heroAppearanceCreater[charactersData[i].Class];
                heroAppearanceCreater.CreateAppereance(character.GetComponent<Appearance>(), charactersData[i], false);
                HeroPassiveSkills heroPassiveSkills = _heroPassiveSkills[_charactersData[i].Class];

/*                for (int j = 0; j < _charactersData[i].SkillsID.Length; j++)
                {
                    Debug.Log(_charactersData[i].SkillsID[j]);
                    Ability ability = heroPassiveSkills.GetSkill(_charactersData[i].SkillsID[j]);
                    ability.SetAbility(character.transform.GetChild(1).GetComponent<Recruit>());
                }*/

                CharacterStats characterStats = character.GetComponent<CharacterStats>();
                characterStats.SetName(charactersData[i].Name);
                characterStats.SetBaseStats(charactersData[i].Attack, charactersData[i].Defense, charactersData[i].Health, charactersData[i].Magic);
            }
        }

        _charactersData = charactersData;
    }

    public void Save()
    {
        for (int i = 0; i < _tavernUI.ContainerTransform.childCount; i++)
        {
            if(_tavernUI.ContainerTransform.GetChild(i).GetComponentInChildren<CharacterStats>() == null)
            {
                _charactersData[i].SetClass(-1);
            }
        }

        BinarySavingSystem.SaveTavern(_charactersData);
    }
}
