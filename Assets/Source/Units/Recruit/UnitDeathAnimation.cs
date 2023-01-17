using System.Collections;
using UnityEngine;

public class UnitDeathAnimation : MonoBehaviour
{
    private readonly float _destroyTime = 1;
    private readonly string _waitUntilDid = "WaitUntilDie";

    private void OnEnable()
    {
        StartCoroutine(_waitUntilDid);
    }

    private void OnDestroy()
    {
        StopCoroutine(_waitUntilDid);
    }

    private IEnumerator WaitUntilDie()
    {
        yield return new WaitForSeconds(_destroyTime);

        Destroy(gameObject);
    }
}
