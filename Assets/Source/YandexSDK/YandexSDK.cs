using Agava.YandexGames;
using System;
using System.Collections;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{
    [SerializeField] private GameObject _buttonAutorize;
    [SerializeField] private SaveComparison _comparison;
    [SerializeField] private CheckLanguage _checkLanguage;
    [SerializeField] private GameObject _leaderboard;

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
            OpenLeaderBoard();

        _checkLanguage.Init();
    }

    public void AuthorizePlayer()
    {
        Action<JsonDataSaves> isSucces = new Action<JsonDataSaves>(SuccesSaves);
        _comparison.TryGetData(isSucces);
        Action autorized = new Action(OffButton);
        PlayerAccount.Authorize(autorized);
    }

    private void SuccesSaves(JsonDataSaves jsonDataSaves)
    {
        _comparison.SetLocal(jsonDataSaves);
    }

    private void OffButton()
    {
        OpenLeaderBoard();
        _comparison.Compare();
    }

    private void OpenLeaderBoard()
    {
        _buttonAutorize.SetActive(false);
        _leaderboard.SetActive(true);
    }
}