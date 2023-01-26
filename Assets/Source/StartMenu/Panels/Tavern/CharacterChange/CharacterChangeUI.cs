using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChangeUI : AllCharactersPanel
{
    private GameObject _currentButton;

    private void OnDisable()
    {
        DeleteAllButtons();
    }

    public void Init(CharactersStorage charactersStorage, GameObject button)
    {
        CharactersStorage = charactersStorage;
        _currentButton = button;
        AddGraphics();
    }

    protected override void AddListenerButton(GameObject button, int id)
    {
        Button tempButton = button.GetComponent<Button>();
        tempButton.onClick.AddListener(delegate { CharactersStorage.DeleteCharacter(id); });
        tempButton.onClick.AddListener(delegate { ChangeCharacter(); });
        tempButton.onClick.AddListener(delegate { ClosePanel(); });
    }

    private void ChangeCharacter()
    {
        _currentButton.GetComponentInChildren<Button>().onClick.Invoke();
    }

    private void ClosePanel()
    {
        string off = "ClosePanel";

        this.gameObject.TryGetComponent<Animator>(out Animator panelAnim);
        panelAnim.SetTrigger(off);
    }

    private void PanelOff()
    {
        this.gameObject.SetActive(false);
    }
}
