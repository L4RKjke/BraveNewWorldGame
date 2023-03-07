using Agava.YandexGames;
using UnityEngine;

public class ChangeSaves : MonoBehaviour
{
    private JsonDataSaves _local;

    public void Init(JsonDataSaves local)
    {
        _local = local;
    }

    public void SetLocalSaves()
    {
        string saves = JsonUtility.ToJson(_local);
        PlayerAccount.SetPlayerData(saves);
        this.gameObject.SetActive(false);
    }
}
