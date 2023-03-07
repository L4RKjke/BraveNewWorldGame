using Agava.YandexGames;
using System.IO;
using UnityEngine;

public class ResetSaves : MonoBehaviour
{
    public void DeleteSaves()
    {
        PlayerAccount.SetPlayerData("");

        string path = Application.persistentDataPath + "/save/save.b";

        if (File.Exists(path))
        {
            path = Application.persistentDataPath + "/save";
            Directory.Delete(path);
        }
    }
}
