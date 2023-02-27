using Agava.YandexGames;
using System;
using System.Collections;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{
    [SerializeField] private GameObject _buttonAutorize;
    /*[SerializeField] private YandexLeaderboard _leaderboard;*/

    private Coroutine _authorize;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();

        InterstitialAd.Show();

/*        if (PlayerAccount.IsAuthorized == true)
            _leaderboard.FormListOfTopPlayers();
        else
            _leaderboard.UpdateLeaderBoardOn();*/
    }

    public void ShowVideoAD()
    {
        Time.timeScale = 0;
        VideoAd.Show();
    }

    public void AuthorizePlayer()
    {
        PlayerAccount.Authorize();

        if (_authorize != null)
            StopCoroutine(_authorize);

        _authorize = StartCoroutine(CheckAuthorize());
    }

    private IEnumerator CheckAuthorize()
    {
        while(PlayerAccount.IsAuthorized == false)
        {
            yield return new WaitForSeconds(0.5f);
        }

        _buttonAutorize.SetActive(false);
    }
}