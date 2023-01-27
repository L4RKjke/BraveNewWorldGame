using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField] private string _panelName;
    [SerializeField] private TMP_Text _panelText;

    private void Start()
    {
        _panelText.text = _panelName;
    }

    public void PanelOff()
    {
        this.gameObject.SetActive(false);
    }

    public void ClosePanel(GameObject panel)
    {
        string off = "ClosePanel";

        panel.TryGetComponent<Animator>(out Animator panelAnim);
        panelAnim.SetTrigger(off);
    }
}
