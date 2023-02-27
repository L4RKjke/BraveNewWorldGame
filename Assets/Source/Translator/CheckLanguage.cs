using Agava.YandexGames;
using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LeanLocalization))]
public class CheckLanguage : MonoBehaviour
{
    private LeanLocalization _localization;

    public void Init()
    {
        string firstEnter = "FirstEnter";

        if (PlayerPrefs.HasKey(firstEnter) == false)
        {
            _localization = GetComponent<LeanLocalization>();

            PlayerPrefs.SetInt(firstEnter, 1);
            string language = YandexGamesSdk.Environment.i18n.lang.ToString();

            if (language == "ru")
                _localization.SetCurrentLanguage("Russian");
            else
                _localization.SetCurrentLanguage("English");
        }
    }

}
