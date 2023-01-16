using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionGetter : MonoBehaviour
{
    private void Update()
    {
        Resolution[] resolutions = Screen.resolutions;

        foreach (var res in resolutions)
        {
            Debug.Log(res.width + "x" + res.height + " : " + res.refreshRate);
        }
    }
}
