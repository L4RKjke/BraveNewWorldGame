using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletSaveLoad : MonoBehaviour , BinarrySaveLoad
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private PlayerProgress _progress;

    public void Load()
    {
        WalletData walletData = BinarySavingSystem.LoadWallet();

        if (walletData != null)
        {
            _wallet.ChangeCrystals(walletData.Crystals - _wallet.Crystals);
            _wallet.ChangeGold(walletData.Gold - _wallet.Gold);
            _progress.SetLevel(walletData.OpenedLevels);
        }

        Debug.Log(walletData.Gold);
    }

    public void Save()
    {
        BinarySavingSystem.SaveWallet(_wallet, _progress);
        Temp();
    }

    public void Temp()
    {
        WalletData walletData = BinarySavingSystem.LoadWallet();
        Debug.Log(walletData.Gold);
    }
}
