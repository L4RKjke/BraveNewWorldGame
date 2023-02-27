using Agava.YandexGames;
using System;
using System.Collections;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{
    [SerializeField] private GameObject _buttonAutorize;
    [SerializeField] private SaveComparison _comparison;
    [SerializeField] private CheckLanguage _checkLanguage;
    /*[SerializeField] private YandexLeaderboard _leaderboard;*/

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();

        InterstitialAd.Show();

        if (PlayerAccount.IsAuthorized)
            OffButton();

        _checkLanguage.Init();

/*        if (PlayerAccount.IsAuthorized == true)
            _leaderboard.FormListOfTopPlayers();
        else
            _leaderboard.UpdateLeaderBoardOn();*/
    }

    public void AuthorizePlayer()
    {
        JsonDataSaves local = _comparison.TryGetData();
        _comparison.SetLocal(local);
        Action autorized = new Action(OffButton);
        PlayerAccount.Authorize(autorized);
    }

    private void OffButton()
    {
        _buttonAutorize.SetActive(false);
        _comparison.Compare();
    }
}