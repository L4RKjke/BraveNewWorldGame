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

            string charactersPath = Application.persistentDataPath + "/characters";
            DirectoryInfo directiryInfo = new DirectoryInfo(charactersPath);
            directiryInfo.Create();

            string itemsPath = Application.persistentDataPath + "/items";
            directiryInfo = new DirectoryInfo(itemsPath);
            directiryInfo.Create();
        }
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

    public static void SaveCharacter(CharacterData characterData, int number)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/characters/character" + number + ".b";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, characterData);
        fileStream.Close();
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

    public static void SaveItem(ItemData item, int number)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/items/item" + number + ".b";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, item);
        fileStream.Close();
    }

    public static List<ItemData> LoadItems()
    {
        List<ItemData> itemDatas = new List<ItemData>();
        bool isItemExist = true;
        int itemNumber = 0;
        string path;

        while (isItemExist)
        {
            path = Application.persistentDataPath + "/items/item" + itemNumber + ".b";

            if(File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(path, FileMode.Open);

                itemDatas.Add(formatter.Deserialize(fileStream) as ItemData);
                fileStream.Close();
                itemNumber++;
            }
            else
            {
                isItemExist = false;
            }
        }

        return itemDatas;
    }
}
