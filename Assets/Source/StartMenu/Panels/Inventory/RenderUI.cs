using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RenderUI : MonoBehaviour
{
    [SerializeField] protected GameObject Ñontainer;
    [SerializeField] protected GameObject Content;

    protected abstract void AddGraphics();

    protected void DeleteAllButtons()
    {
        for (int i = 0; i < Content.transform.childCount; i++)
        {
            Destroy(Content.transform.GetChild(i).gameObject);
        }
    }
}
