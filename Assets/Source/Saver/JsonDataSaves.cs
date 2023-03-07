using System.Collections.Generic;

[System.Serializable]
public class JsonDataSaves
{
    public WalletData WalletData;
    public EquipItemData[] EquippedItems;
    public CharacterData[] TavernData;
    public CharacterData[] CharactersData;
    public ShopData ShopData;
    public ItemInventoryData ItemInventoryData;
    public ItemData ItemData;

    public JsonDataSaves(WalletData playerWallet, List<EquipItemData> equippedItems,List<CharacterData> charactersData,
        List<CharacterData> tavernData, ShopData shopData, ItemInventoryData itemInventoryData, ItemData itemData)
    {
        WalletData = playerWallet;
        CharactersData = new CharacterData[charactersData.Count];
        TavernData = new CharacterData[tavernData.Count];
        EquippedItems = new EquipItemData[equippedItems.Count];

        for (int i = 0; i < equippedItems.Count; i++)
        {
            EquippedItems[i] = equippedItems[i];
        }

        for (int i = 0; i < charactersData.Count; i++)
        {
            CharactersData[i] = charactersData[i];
        }

        for (int i = 0; i < tavernData.Count; i++)
        {
            TavernData[i] = tavernData[i];
        }

        ShopData = shopData;
        ItemInventoryData = itemInventoryData;
        ItemData = itemData;
    }
}
