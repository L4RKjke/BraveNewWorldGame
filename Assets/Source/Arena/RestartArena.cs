using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartArena : MonoBehaviour
{
    public void OnRestart()
    {
        SceneManager.LoadScene(0);
    }
}
