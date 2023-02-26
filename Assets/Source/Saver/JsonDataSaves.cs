using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JsonDataSaves
{
    public WalletData WalletData;
    public EquippedItemsData EquippedItems;
    public CharacterData[] TavernData;
    public CharacterData[] CharactersData;
    public ShopData ShopData;
    public ItemInventoryData ItemInventoryData;
    public ItemData ItemData;

    public JsonDataSaves(WalletData playerWallet, EquippedItemsData equippedItems,List<CharacterData> charactersData,
        List<CharacterData> tavernData, ShopData shopData, ItemInventoryData itemInventoryData, ItemData itemData)
    {
        WalletData = playerWallet;
        EquippedItems = equippedItems;
        CharactersData = new CharacterData[charactersData.Count];
        TavernData = new CharacterData[tavernData.Count];

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
