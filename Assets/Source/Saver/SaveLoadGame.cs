using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WalletSaveLoad))]
[RequireComponent(typeof(CharactersSaveLoad))]
[RequireComponent(typeof(ItemsSaveLoad))]
[RequireComponent(typeof(ItemInventorySaveLoad))]
[RequireComponent(typeof(EquippedItemsSaveLoad))]
[RequireComponent(typeof(ShopSaveLoad))]
[RequireComponent(typeof(TavernSaveLoad))]
public class SaveLoadGame : MonoBehaviour , BinarrySaves
{
    [SerializeField] private FinalPanels _finalPanels;
    [SerializeField] private DoublePanel _panel;
    [SerializeField] private List<ButtonUpdate> _updates;

    private WalletSaveLoad _wallet;
    private CharactersSaveLoad _charactersSaveLoad;
    private ItemsSaveLoad _itemsSaveLoad;
    private ItemInventorySaveLoad _itemInventorySaveLoad;
    private EquippedItemsSaveLoad _equippedItemsSaveLoad;
    private ShopSaveLoad _shopSaveLoad;
    private TavernSaveLoad _tavernSaveLoad;

    public UnityAction Saved;

    private void Awake()
    {
        _wallet = GetComponent<WalletSaveLoad>();
        _charactersSaveLoad = GetComponent<CharactersSaveLoad>();
        _itemsSaveLoad = GetComponent<ItemsSaveLoad>();
        _itemInventorySaveLoad = GetComponent<ItemInventorySaveLoad>();
        _equippedItemsSaveLoad = GetComponent<EquippedItemsSaveLoad>();
        _shopSaveLoad = GetComponent<ShopSaveLoad>();
        _tavernSaveLoad = GetComponent<TavernSaveLoad>();
    }

    private void OnEnable()
    {
        if (_finalPanels != null)
        {
            _finalPanels.BattleEnd += Save;
            _panel.PanelClosed += Save;

            for (int i = 0; i < _updates.Count; i++)
            {
                _updates[i].Updated += SaveDelay;
            }
        }
    }

    private void OnDisable()
    {
        if (_finalPanels != null)
        {
            _finalPanels.BattleEnd -= Save;
            _panel.PanelClosed -= Save;

            for (int i = 0; i < _updates.Count; i++)
            {
                _updates[i].Updated -= SaveDelay;
            }
        }
    }

    public void Load(WalletData walletData, List<CharacterData> charactersData, ItemData itemData, ItemInventoryData itemInventoryData,
        EquippedItemsData equippedItemsData, ShopData shopData, List<CharacterData> tavernData)
    {
        _wallet.Load(walletData);
        _charactersSaveLoad.Load(charactersData);
        _itemsSaveLoad.Load(itemData);
        _itemInventorySaveLoad.Load(itemInventoryData);
        _equippedItemsSaveLoad.Load(equippedItemsData);
        _shopSaveLoad.Load(shopData);
        _tavernSaveLoad.Load(tavernData);
    }

    public void Save()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        _wallet.Save();
        _charactersSaveLoad.Save();
        _itemsSaveLoad.Save();
        _itemInventorySaveLoad.Save();
        _equippedItemsSaveLoad.Save();
        _shopSaveLoad.Save();
        _tavernSaveLoad.Save();
#endif

        Saved?.Invoke();
    }

    public void SaveDelay()
    {
        StartCoroutine(CoroutineSaveDelay());
    }

    public string GetJson()
    {
        WalletData walletData = _wallet.GetData();
        EquippedItemsData equippedItemsData = _equippedItemsSaveLoad.GetData();
        List<CharacterData> charactersData = _charactersSaveLoad.GetData();
        List<CharacterData> tavernData = _tavernSaveLoad.GetData();
        ShopData shopData = _shopSaveLoad.GetData();
        ItemInventoryData itemInventory = _itemInventorySaveLoad.GetData();
        ItemData itemData = _itemsSaveLoad.GetData();

        JsonDataSaves jsonDataSaves = new JsonDataSaves(walletData, equippedItemsData, charactersData, tavernData, shopData, itemInventory, itemData);
        string saves = JsonUtility.ToJson(jsonDataSaves);

        return saves;
    }

    public void Test()
    {
        GetJson();
    }

    public void JsonLoad(string value)
    {
        JsonDataSaves jsonDataSaves = JsonUtility.FromJson<JsonDataSaves>(value);

        List<CharacterData> charactersData = new List<CharacterData>();
        List<CharacterData> tavernData = new List<CharacterData>();

        for (int i = 0; i < jsonDataSaves.CharactersData.Length; i++)
        {
            charactersData.Add(jsonDataSaves.CharactersData[i]);
        }

        for (int i = 0; i < jsonDataSaves.TavernData.Length; i++)
        {
            tavernData.Add(jsonDataSaves.TavernData[i]);
        }

        Load(jsonDataSaves.WalletData, charactersData, jsonDataSaves.ItemData, jsonDataSaves.ItemInventoryData,
            jsonDataSaves.EquippedItems, jsonDataSaves.ShopData, tavernData);
    }

    private IEnumerator CoroutineSaveDelay()
    {
        float delay = 1;
        yield return new WaitForSeconds(delay);
        Save();
    }
}
