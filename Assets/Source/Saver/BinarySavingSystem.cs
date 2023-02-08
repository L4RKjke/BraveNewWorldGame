using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinarySavingSystem
{
    public static void CreateDirectoryInfo()
    {
        string pathSave = Application.persistentDataPath + "/save.b";

        if (File.Exists(pathSave) == false)
        {
            FileStream fileStream = new FileStream(pathSave, FileMode.Create);
            fileStream.Close();

            string path = Application.persistentDataPath + "/characters";
            CreateDirectory(path);
        }
    }

    private static void CreateDirectory(string path)
    {
        DirectoryInfo directiryInfo = new DirectoryInfo(path);
        directiryInfo.Create();
    }

    public static void SaveWallet(PlayerWallet wallet)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/wallet.b";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        WalletData data = new WalletData(wallet);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static WalletData LoadWallet()
    {
        string path = Application.persistentDataPath + "/wallet.b";

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
            string path = Application.persistentDataPath + "/characters/character" + i + ".b";
            FileStream fileStream = new FileStream(path, FileMode.Create);

            formatter.Serialize(fileStream, charactersData[i]);
            fileStream.Close();
            characterNumber = i;
        }

        characterNumber++;

        while (File.Exists(Application.persistentDataPath + "/characters/character" + characterNumber + ".b"))
        {
            File.Delete(Application.persistentDataPath + "/characters/character" + characterNumber + ".b");
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
            path = Application.persistentDataPath + "/characters/character" + characterNumber + ".b";

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
        string path = Application.persistentDataPath + "/items.b";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        ItemData data = new ItemData(playerItemStorage);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static ItemData LoadItems()
    {
        string path = Application.persistentDataPath + "/items.b";

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
        string path = Application.persistentDataPath + "/itemsInventory.b";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        ItemInventoryData data = new ItemInventoryData(inventoryStorage);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static ItemInventoryData LoadItemInventory()
    {
        string path = Application.persistentDataPath + "/itemsInventory.b";

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
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/equippedItems.b";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        EquippedItemsData data = new EquippedItemsData(characterStorage);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static EquippedItemsData LoadEquippedItems()
    {
        string path = Application.persistentDataPath + "/equippedItems.b";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            EquippedItemsData data = formatter.Deserialize(fileStream) as EquippedItemsData;
            fileStream.Close();

            return data;
        }

        return null;
    }

    public static void SaveShop(ItemShopUI itemShop)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shop.b";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        ShopData data = new ShopData(itemShop);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static ShopData LoadShop()
    {
        string path = Application.persistentDataPath + "/shop.b";

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
            string path = Application.persistentDataPath + "/characters/characterTavern" + i + ".b";
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
            path = Application.persistentDataPath + "/characters/characterTavern" + characterNumber + ".b";

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
}
