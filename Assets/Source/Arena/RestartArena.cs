using UnityEngine;

public class RestartArena : MonoBehaviour
{
    [SerializeField] private UnitPool _pool;
    [SerializeField] private ArenaCells _arenaCells;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _startBattleCanvas;

    public void OnRestart()
    {
        Debug.Log("restart");
        _winPanel.SetActive(false);
        _losePanel.SetActive(false);
        _startBattleCanvas.SetActive(true);
        _pool.CleanPool();
        _arenaCells.PrepareArena();
        _startButton.SetActive(true);
    }
}
