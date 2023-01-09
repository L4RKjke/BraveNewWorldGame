using System.Collections;
using UnityEngine;

public class ImmortalState : State
{
    private readonly float _immartalityTime = 3;

    private void Awake()
    {
        Fighter.MakeImmortal();
        StartCoroutine(RemoveImmortality());
    }

    private void OnDisable()
    {
        StopCoroutine(RemoveImmortality());
    }

    private IEnumerator RemoveImmortality()
    {
        yield return new WaitForSeconds(_immartalityTime);

        Fighter.MakeMortal();
    }
}
