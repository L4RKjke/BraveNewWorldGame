using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveLoadGame))]
public class Loader : MonoBehaviour
{
    [SerializeField] private SaveLoadYandex _yandex;

    private SaveLoadGame _game;

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        _game = GetComponent<SaveLoadGame>();
        WalletData walletData = BinarySavingSystem.LoadWallet();
        List<CharacterData> charactersData = BinarySavingSystem.LoadCharacter();
        ItemData items = BinarySavingSystem.LoadItems();
        ItemInventoryData itemInventoryData = BinarySavingSystem.LoadItemInventory();
        List<EquipItemData> equippedItemsData = BinarySavingSystem.LoadEquippedItems();
        ShopData shopData = BinarySavingSystem.LoadShop();
        List<CharacterData> tavernData = BinarySavingSystem.LoadTavern();
        _game.Load(walletData, charactersData, items, itemInventoryData, equippedItemsData, shopData, tavernData);
        yield break;
#endif

        BinarySavingSystem.CreateDirectoryInfo();
        _yandex.GetData();
        yield break;
    }
}
