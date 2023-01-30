using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private Camera _cameraMenu;
    [SerializeField] private Camera _cameraBattle;

    public void StartBattle()
    {
        _cameraBattle.enabled = true;
        _cameraMenu.enabled = false;
    }

    public void ReturnToMenu()
    {
        _cameraMenu.enabled = true;
        _cameraBattle.enabled = false;
    }
}
