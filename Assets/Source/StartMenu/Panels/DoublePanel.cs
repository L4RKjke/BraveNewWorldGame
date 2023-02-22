using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoublePanel : Panel
{
    private GameObject _secondPanel;

    public UnityAction PanelClosed;

    private void OnDisable()
    {
        PanelClosed?.Invoke();
    }

    public void OpenSecondPanel(GameObject panel)
    {
        _secondPanel = panel;
        _secondPanel.SetActive(true);
    }

    public void CloseSecondPanel()
    {
        string off = "ClosePanel";

        _secondPanel.TryGetComponent<Animator>(out Animator panelAnim);
        panelAnim.SetTrigger(off);
    }
}
