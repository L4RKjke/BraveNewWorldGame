using UnityEngine;

public class AnaliticsLevelListener : MonoBehaviour
{
    [SerializeField] private Analytics _analytics;
    [SerializeField] private PanelHunt _huntPanel;
    [SerializeField] private Arena _arena;

    private void OnEnable()
    {
        _arena.PlayerWin += OnPlayerWin;
        _arena.PlayerLose += OnPlayerLose;
        _arena.BattleStarted += OnLevelStart;
    }

    private void OnDisable()
    {
        _arena.PlayerWin -= OnPlayerWin;
        _arena.PlayerLose -= OnPlayerLose;
        _arena.BattleStarted -= OnLevelStart;
    }

    private void OnLevelStart()
    {
        _analytics.OnStart(_huntPanel.GetCurrentLevel().ToString());
    }

    private void OnPlayerWin()
    {
        _analytics.OnComplete(_huntPanel.GetCurrentLevel().ToString());
    }

    private void OnPlayerLose()
    {
        _analytics.OnFail(_huntPanel.GetCurrentLevel().ToString());
    }
}