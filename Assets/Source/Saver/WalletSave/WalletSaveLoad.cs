using UnityEngine;

public class WalletSaveLoad : MonoBehaviour , BinarrySaves
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private PlayerProgress _progress;

    public void Load(WalletData walletData)
    {
        if (walletData != null)
        {
            _wallet.ChangeCrystals(walletData.Crystals - _wallet.Crystals);
            _wallet.ChangeGold(walletData.Gold - _wallet.Gold);
            _progress.SetLevel(walletData.OpenedLevels);
        }
    }

    public void Save()
    {
        BinarySavingSystem.SaveWallet(_wallet, _progress);
    }

    public WalletData GetData()
    {
        WalletData walletData = new WalletData(_wallet,_progress);
        return walletData;
    }
}
