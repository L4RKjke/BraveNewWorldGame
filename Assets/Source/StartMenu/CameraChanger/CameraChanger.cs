using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private Camera _cameraMenu;

    private Camera _previos;
    private Camera _current;

    private void Awake()
    {
        _current = _cameraMenu;
    }

    public void GoToNext(Camera camera)
    {
        camera.enabled = true;
        _current.enabled = false;
        _previos = _current;
        _current = camera;
    }

    public void ReturnToPrevios()
    {
        _previos.enabled = true;
        _current.enabled = false;
        Camera temp = _previos;
        _previos = _current;
        _current = temp;
    }
}
