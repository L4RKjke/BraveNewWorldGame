using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResetSaves : MonoBehaviour
{
    public void DeleteSaves()
    {
        Debug.Log("удаляю");
        PlayerAccount.SetPlayerData("");

        string path = Application.persistentDataPath + "/save/save.b";

        if (File.Exists(path))
        {
            path = Application.persistentDataPath + "/save";
            Directory.Delete(path);
        }

        Debug.Log("Все готово");
    }
}
