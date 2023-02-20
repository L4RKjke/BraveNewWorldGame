using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private Image _levelBar;
    [SerializeField] private TMP_Text _expText;

    public void SetLevel(CharacterStats characterStats)
    {
        _level.text = characterStats.Level.ToString();
        float expTemp = characterStats.Exp;
        float fill = (expTemp - ((characterStats.Level - 1) * characterStats.ExpPerLevel)) / characterStats.ExpPerLevel;
        _levelBar.fillAmount = fill;
        _expText.text = characterStats.Exp - (characterStats.Level * characterStats.ExpPerLevel) + characterStats.ExpPerLevel + "/" + characterStats.ExpPerLevel;
    }
}
