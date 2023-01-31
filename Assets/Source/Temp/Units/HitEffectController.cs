using UnityEngine;

public class HitEffectController : MonoBehaviour
{
    private readonly float _effectLifeTime = 0.5f;

    private void OnEnable()
    {
        Destroy(gameObject, _effectLifeTime);
    }
}
