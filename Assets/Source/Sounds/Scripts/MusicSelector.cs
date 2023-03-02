using UnityEngine;

public class MusicSelector : MonoBehaviour
{
    [SerializeField] private AudioClip _fightMusic;
    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _arenaMusic;
    [SerializeField] private AudioSource _currentSong;

    public void SelectMusic(MusicType type)
    {
        switch (type)
        {
            case MusicType.Menu:
                ChangeCurrentMusic(_menuMusic);
                break;

            case MusicType.Arena:
                ChangeCurrentMusic(_arenaMusic);
                break;

            case MusicType.Battle:
                ChangeCurrentMusic(_fightMusic);
                break;
        }
    }

    private void ChangeCurrentMusic(AudioClip song)
    {
        _currentSong.clip = song;
        _currentSong.Play();
    }
}

public enum MusicType
{
    Menu,
    Arena,
    Battle
}