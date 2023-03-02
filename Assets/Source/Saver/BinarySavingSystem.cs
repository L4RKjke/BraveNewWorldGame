using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinarySavingSystem
{
    public static void CreateDirectoryInfo()
    {
        string pathSave = Application.persistentDataPath + "/save/save.b";

        if (File.Exists(pathSave) == false)
        {
            string path = Application.persistentDataPath + "/save/characters";
            CreateDirectory(path);
            path = Application.persistentDataPath + "/save/itemsEquip";
            CreateDirectory(path);

            FileStream fileStream = new FileStream(pathSave, FileMode.Create);
            fileStream.Close();
        }
    }

    public static bool CheckSaves()
    {
        bool isCreated = true;
        string pathSave = Application.persistentDataPath + "/save/save.b";

        if (File.Exists(pathSave) == false)
            isCreated = false;

        return isCreated;
    }

    private static void CreateDirectory(string path)
    {
        DirectoryInfo directiryInfo = new DirectoryInfo(path);
        directiryInfo.Create();
    }

    public static void SaveWallet(PlayerWallet wallet, PlayerProgress progress)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save/wallet.b";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        WalletData data = new WalletData(wallet, progress);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static WalletData LoadWallet()
    {
        string path = Application.persistentDataPath + "/save/wallet.b";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            WalletData data = formatter.Deserialize(fileStream) as WalletData;
            fileStream.Close();

            return data;
        }

        return null;
    }

    public static void SaveCharacters(List<CharacterData> charactersData)
    {
        int characterNumber = -1;

        for (int i = 0; i < charactersData.Count; i++)
        {

            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/save/characters/character" + i + ".b";
            FileStream fileStream = new FileStream(path, FileMode.Create);

            formatter.Serialize(fileStream, charactersData[i]);
            fileStream.Close();
            characterNumber = i;
        }

        characterNumber++;

        while (File.Exists(Application.persistentDataPath + "/save/characters/character" + characterNumber + ".b"))
        {
            File.Delete(Application.persistentDataPath + "/save/characters/character" + characterNumber + ".b");
            characterNumber++;
        }
    }

    public static List<CharacterData> LoadCharacter()
    {
        List<CharacterData> characters = new List<CharacterData>();
        bool isCharacterExist = true;
        int characterNumber = 0;
        string path;

        while (isCharacterExist)
        {
            path = Application.persistentDataPath + "/save/characters/character" + characterNumber + ".b";

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(path, FileMode.Open);

                characters.Add(formatter.Deserialize(fileStream) as CharacterData);
                fileStream.Close();
                characterNumber++;
            }
            else
            {
                isCharacterExist = false;
            }
        }

        return characters;
    }

    public static void SaveItem(PlayerItemStorage playerItemStorage)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save/items.b";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        ItemData data = new ItemData(playerItemStorage);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static ItemData LoadItems()
    {
        string path = Application.persistentDataPath + "/save/items.b";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            ItemData data = formatter.Deserialize(fileStream) as ItemData;
            fileStream.Close();

            return data;
        }

        return null;
    }

    public static void SaveItemInventory(InventoryStorage inventoryStorage)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save/itemsInventory.b";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        ItemInventoryData data = new ItemInventoryData(inventoryStorage);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static ItemInventoryData LoadItemInventory()
    {
        string path = Application.persistentDataPath + "/save/itemsInventory.b";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            ItemInventoryData data = formatter.Deserialize(fileStream) as ItemInventoryData;
            fileStream.Close();

            return data;
        }

        return null;
    }

    public static void SaveEquippedItems(CharactersStorage characterStorage)
    {
        EquippedItemsData itemsData = new EquippedItemsData(characterStorage);
        List<EquipItemData> _items = itemsData.GetItems();
        int itemNumber = -1;

        for (int i = 0; i < _items.Count; i++)
        {

            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/save/itemsEquip/item" + i + ".b";
            FileStream fileStream = new FileStream(path, FileMode.Create);

            formatter.Serialize(fileStream, _items[i]);
            fileStream.Close();
            itemNumber = i;
        }
        itemNumber++;

        while (File.Exists(Application.persistentDataPath + "/save/itemsEquip/item" + itemNumber + ".b"))
        {
            File.Delete(Application.persistentDataPath + "/save/itemsEquip/item" + itemNumber + ".b");
            itemNumber++;
        }
    }

    public static List<EquipItemData> LoadEquippedItems()
    {
        List<EquipItemData> items = new List<EquipItemData>();
        bool isItemExist = true;
        int itemNumber = 0;
        string path;

        while (isItemExist)
        {
            path = Application.persistentDataPath + "/save/itemsEquip/item" + itemNumber + ".b";

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(path, FileMode.Open);

                items.Add(formatter.Deserialize(fileStream) as EquipItemData);
                fileStream.Close();
                itemNumber++;
            }
            else
            {
                isItemExist = false;
            }
        }

        return items;
    }

    public static void SaveShop(ItemShopUI itemShop)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save/shop.b";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        ShopData data = new ShopData(itemShop);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static ShopData LoadShop()
    {
        string path = Application.persistentDataPath + "/save/shop.b";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            ShopData data = formatter.Deserialize(fileStream) as ShopData;
            fileStream.Close();

            return data;
        }

        return null;
    }

    public static void SaveTavern(List<CharacterData> charactersData)
    {
        for (int i = 0; i < charactersData.Count; i++)
        {

            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/save/characters/characterTavern" + i + ".b";
            FileStream fileStream = new FileStream(path, FileMode.Create);

            formatter.Serialize(fileStream, charactersData[i]);
            fileStream.Close();
        }
    }

    public static List<CharacterData> LoadTavern()
    {
        List<CharacterData> characters = new List<CharacterData>();
        bool isCharacterExist = true;
        int characterNumber = 0;
        string path;

        while (isCharacterExist)
        {
            path = Application.persistentDataPath + "/save/characters/characterTavern" + characterNumber + ".b";

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(path, FileMode.Open);

                characters.Add(formatter.Deserialize(fileStream) as CharacterData);
                fileStream.Close();
                characterNumber++;
            }
            else
            {
                isCharacterExist = false;
            }
        }

        return characters;
    }

    public static void SaveJSON(string data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save/json.b";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static string LoadJSON()
    {
        string path = Application.persistentDataPath + "/save/json.b";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            string data = formatter.Deserialize(fileStream) as string;
            fileStream.Close();

            return data;
        }

        return null;
    }
}
