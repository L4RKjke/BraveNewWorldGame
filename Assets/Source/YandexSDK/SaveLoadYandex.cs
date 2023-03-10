using Agava.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveLoadGame))]
public class SaveLoadYandex : MonoBehaviour
{
    private SaveLoadGame _game;
    private bool _loaded = false;

    private void Awake()
    {
        _game = GetComponent<SaveLoadGame>();
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        _game.Saved += SetData;
        yield break;
    }

    public void GetData()
    {
        Action<string> getData = new Action<string>(LoadData);
        Action<string> failData = new Action<string>(LoadDataFail);
        PlayerAccount.GetPlayerData(getData, failData);
    }

    private void SetData()
    {
        string saves = _game.GetJson();
        PlayerAccount.SetPlayerData(saves);
    }

    private void LoadDataFail(string data)
    {
        WalletData walletData = BinarySavingSystem.LoadWallet();
        List<CharacterData> charactersData = BinarySavingSystem.LoadCharacter();
        ItemData items = BinarySavingSystem.LoadItems();
        ItemInventoryData itemInventoryData = BinarySavingSystem.LoadItemInventory();
        List<EquipItemData> equippedItemsData = BinarySavingSystem.LoadEquippedItems();
        ShopData shopData = BinarySavingSystem.LoadShop();
        List<CharacterData> tavernData = BinarySavingSystem.LoadTavern();
        _game.Load(walletData, charactersData, items, itemInventoryData, equippedItemsData, shopData, tavernData);
    }

    private void LoadData(string data)
    {
        _loaded = true;
        _game.JsonLoad(data);
    }
}
