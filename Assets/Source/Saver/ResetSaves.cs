using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResetSaves : MonoBehaviour
{
    public void DeleteSaves()
    {
        PlayerAccount.SetPlayerData("");

        string path = Application.persistentDataPath + "/save";

        if (Directory.Exists(path))
            Directory.Delete(path);
    }


}
