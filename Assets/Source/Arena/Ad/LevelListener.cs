using Agava.YandexGames;
using UnityEngine;

public class LevelListener : MonoBehaviour
{
    [SerializeField] private FinalPanels _finalPanel;

    private int _advertismentDelay = 6;

    private void OnEnable()
    {
        _finalPanel.BattleEnd += ShowAdvertisment;
    }

    private void OnDisable()
    {
        _finalPanel.BattleEnd -= ShowAdvertisment;
    }

    private void ShowAdvertisment()
    {
        _advertismentDelay--;

        if (_advertismentDelay == 0)
        {
            _advertismentDelay = 4;

            VideoAd.Show(null, null, () => AdShowed(), errorLog => OnError(errorLog));

            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                AudioListener.pause = true;
            }

            Time.timeScale = 0;
        }
    }

    private void AdShowed()
    {
        Time.timeScale = 1;

        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.pause = false;
        }
    }

    private void OnError(string errorLog)
    {
        AdShowed();
    }
}