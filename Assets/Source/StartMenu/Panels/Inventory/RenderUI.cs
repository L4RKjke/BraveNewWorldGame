using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RenderUI : MonoBehaviour
{
    [SerializeField] protected GameObject Container;
    [SerializeField] protected GameObject Content;

    protected abstract void AddGraphics();

    protected void DeleteAllButtons()
    {
        for (int i = 0; i < Container.transform.childCount; i++)
        {
            Destroy(Container.transform.GetChild(i).gameObject);
        }
    }
}
