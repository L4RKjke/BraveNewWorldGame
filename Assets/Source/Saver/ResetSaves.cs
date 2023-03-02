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
        File.Delete(Application.persistentDataPath + "/save/save.b");
    }


}
