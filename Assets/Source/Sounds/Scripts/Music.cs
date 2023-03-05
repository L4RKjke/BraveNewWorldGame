using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private ArenaChecker _arenaChecker;
    [SerializeField] private Arena _arena;
    [SerializeField] private MusicSelector _musicSelector;
    [SerializeField] private FinalPanels _finalPanels;

    private void OnEnable()
    {
        _arena.BattleStarted += SetBattleMusic;
        _finalPanels.BattleEnd += SetArenaMusic;
        _arenaChecker.ArenaEnabled += SetArenaMusic;
        _arenaChecker.ArenaDisabled += SetMenuMusic;
    }

    private void Start()
    {
        _musicSelector.SelectMusic(MusicType.Menu);
    }

    private void OnDisable()
    {
        _arena.BattleStarted -= SetBattleMusic;
        _arenaChecker.ArenaEnabled -= SetArenaMusic;
        _arenaChecker.ArenaDisabled -= SetMenuMusic;
        _finalPanels.BattleEnd -= SetArenaMusic;
    }

    private void SetMenuMusic()
    {
        _musicSelector.SelectMusic(MusicType.Menu);
    }

    private void SetArenaMusic()
    {
        _musicSelector.SelectMusic(MusicType.Arena);
    }

    private void SetBattleMusic()
    {
        _musicSelector.SelectMusic(MusicType.Battle);
    }
}