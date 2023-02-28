using UnityEngine;

public class LevelListener : MonoBehaviour
{
    [SerializeField] private FinalPanels _finalPanel;

    private int _advertismentDelay = 5;

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
            //showAd
            _advertismentDelay = 5;
        }
    }
}