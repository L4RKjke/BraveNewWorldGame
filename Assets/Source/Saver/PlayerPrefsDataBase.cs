using UnityEngine;

public static class PlayerPrefsDataBase
{
    public static void SetVolume(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
    }

    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat("Volume");
    }

    public static void SetQuality(int value)
    {
        PlayerPrefs.SetInt("Quality", value);
    }

    public static int GetQuality()
    {
        return PlayerPrefs.GetInt("Quality");
    }

    public static void SetSound(int value)
    {
        PlayerPrefs.SetInt("Sound", value);
    }

    public static int GetSound()
    {
        return PlayerPrefs.GetInt("Sound");
    }
}
