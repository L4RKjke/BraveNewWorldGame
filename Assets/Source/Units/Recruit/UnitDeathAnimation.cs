using System.Collections;
using UnityEngine;

public class UnitDeathAnimation : MonoBehaviour
{
    private readonly float _destroyTime = 1;

    private void OnEnable()
    {
        StartCoroutine("WaitUntilDie");
    }

    private void OnDestroy()
    {
        StopCoroutine("WaitUntilDie");
    }

    private IEnumerator WaitUntilDie()
    {
        yield return new WaitForSeconds(_destroyTime);

        Destroy(gameObject);
    }
}
