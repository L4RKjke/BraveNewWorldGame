using UnityEngine;

public class DeathView : MonoBehaviour
{
    private float _dieTime;

    private void Start()
    {
        Destroy(gameObject, _dieTime);
    }

    private void OnDisable()
    {
        if (!this.gameObject.scene.isLoaded) return;
    }
}
