using System.Collections;
using UnityEngine;

public class HitEffectController : MonoBehaviour
{
    private readonly float _effectLifeTime = 0.4f;
    private readonly string _killCourutine = "KillEffectCourutine";

    private void OnEnable()
    {
        StartCoroutine(_killCourutine);
    }

    private void OnDisable()
    {
        StopCoroutine(_killCourutine);
    }

    private IEnumerator KillEffectCourutine()
    {
        yield return new WaitForSeconds(_effectLifeTime);

        Destroy(gameObject);
    }
}
