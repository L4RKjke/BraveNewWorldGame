using Agava.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveLoadGame))]
public class SaveLoadYandex : MonoBehaviour
{
    private SaveLoadGame _game;

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
        Debug.Log("Подписался");
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
        Debug.Log("Ошибка загрузки, беру бинар");
        WalletData walletData = BinarySavingSystem.LoadWallet();
        List<CharacterData> charactersData = BinarySavingSystem.LoadCharacter();
        ItemData items = BinarySavingSystem.LoadItems();
        ItemInventoryData itemInventoryData = BinarySavingSystem.LoadItemInventory();
        EquippedItemsData equippedItemsData = BinarySavingSystem.LoadEquippedItems();
        ShopData shopData = BinarySavingSystem.LoadShop();
        List<CharacterData> tavernData = BinarySavingSystem.LoadTavern();
        _game.Load(walletData, charactersData, items, itemInventoryData, equippedItemsData, shopData, tavernData);
    }

    private void LoadData(string data)
    {
        Debug.Log("Загружаю Джсон");
        _game.JsonLoad(data);
    }
}
