using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonymousLoader : MonoBehaviour
{
    [SerializeField] private SaveLoadGame _game;

    public void Load()
    {
        WalletData walletData = BinarySavingSystem.LoadWallet();
        List<CharacterData> charactersData = BinarySavingSystem.LoadCharacter();
        ItemData items = BinarySavingSystem.LoadItems();
        ItemInventoryData itemInventoryData = BinarySavingSystem.LoadItemInventory();
        EquippedItemsData equippedItemsData = BinarySavingSystem.LoadEquippedItems();
        ShopData shopData = BinarySavingSystem.LoadShop();
        List<CharacterData> tavernData = BinarySavingSystem.LoadTavern();
        _game.Load(walletData, charactersData, items, itemInventoryData, equippedItemsData, shopData, tavernData);
    }
}
