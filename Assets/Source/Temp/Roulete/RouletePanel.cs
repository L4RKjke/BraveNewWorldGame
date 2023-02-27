using UnityEngine;

public class RouletePanel : MonoBehaviour
{
    [SerializeField] private GameObject _rouletePanel;
    [SerializeField] private GameObject _menuTimer;

    public void OnRouleteButtonClick()
    {
        _rouletePanel.SetActive(true);
        _menuTimer.SetActive(false);
    }

    public void OnRouleteClosePanel()
    {
        _menuTimer.SetActive(true);
        _rouletePanel.SetActive(false);
    }
}
