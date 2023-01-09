using System.Collections;
using UnityEngine;

public abstract class AtackState : State
{
    public abstract void Atack();

    public IEnumerator LaunchActack()
    {
        while (true)
        {
            Atack();
            yield return new WaitForSeconds(2);
        }
    }
}
