[System.Serializable]
public class WalletData
{
    public int Gold;
    public int Crystals;
    public int OpenedLevels;

    public WalletData(PlayerWallet wallet, PlayerProgress playerProgress)
    {
        Gold = wallet.Gold;
        Crystals = wallet.Crystals;
        OpenedLevels = playerProgress.OpenedLevel;
    }
}
