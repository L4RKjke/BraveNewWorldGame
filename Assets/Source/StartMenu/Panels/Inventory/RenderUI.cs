using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RenderUI : MonoBehaviour
{
    [SerializeField] protected GameObject �ontainer;
    [SerializeField] protected GameObject Content;

    protected abstract void AddGraphics();
}
