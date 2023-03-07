using UnityEngine;
using UnityEngine.UI;

public class CharacterChangeUI : AllCharactersPanel
{
    [SerializeField] private PlayerItemStorage _playerItemStorage;

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
        tempButton.onClick.AddListener(delegate { TryChangeCharacter(id); });
    }

    private void TryChangeCharacter(int id)
    {
        GameObject character = CharactersStorage.GetCharacter(id);
        character.GetComponent<CharacterItems>().ReturnItems(_playerItemStorage);

        CharactersStorage.DeleteCharacter(id);
        CharactersStorage.CharactersSaveLoad.DeleteData(id);
        ChangeCharacter();
        ClosePanel();
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
