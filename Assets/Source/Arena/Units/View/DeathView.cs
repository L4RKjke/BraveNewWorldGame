using UnityEngine;

public class DeathView : MonoBehaviour
{
    private readonly float _dieTime = 2;

    private void OnEnable()
    {
        Destroy(gameObject, _dieTime);
    }
}
