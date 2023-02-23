using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasksCompletes : AssistantTask
{
    [SerializeField] private Button _buttonEnd;
    [SerializeField] private SettingsUI _settingsUI;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private SaveLoadGame _save;

    private void Start()
    {
        _buttonEnd.onClick.AddListener(delegate { AddReward(); ; });
        _buttonEnd.onClick.AddListener(delegate { BinarySavingSystem.CreateDirectoryInfo(); ; });
        _buttonEnd.onClick.AddListener(delegate { _save.SaveDelay(); });
        _buttonEnd.onClick.AddListener(delegate { _settingsUI.ReloadSceneLanguage(); });
    }

    private void OnEnable()
    {
        ShowMessage(this);
    }

    private void AddReward()
    {
        int gold = 5000;
        int crystals = 1000;

        _wallet.ChangeCrystals(crystals);
        _wallet.ChangeGold(gold);
    }
}
