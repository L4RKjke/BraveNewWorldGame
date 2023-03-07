using UnityEngine;

public class Panel : MonoBehaviour
{
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
