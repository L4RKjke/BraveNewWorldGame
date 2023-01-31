using UnityEngine;

public class DeathView : MonoBehaviour
{
    private float _dieTime;

    private void Start()
    {
        Destroy(gameObject, _dieTime);
    }
}
