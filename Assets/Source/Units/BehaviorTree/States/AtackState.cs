using System.Collections;
using UnityEngine;

public abstract class AtackState : State
{
    public abstract void StartAtack();

    public void CompleteAtack()
    {
    }

    public IEnumerator LaunchActack()
    {
        while (true)
        {
            StartAtack();
            yield return new WaitForSeconds(2);
        }
    }
}
