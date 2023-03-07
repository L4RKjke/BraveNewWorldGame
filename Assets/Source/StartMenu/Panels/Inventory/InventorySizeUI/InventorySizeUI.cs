using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySizeUI : MonoBehaviour
{
    [SerializeField] private PlayerItemStorage _playerItemStorage;
    [SerializeField] private TMP_Text _textCount;
    [SerializeField] private Image _fillIn;
    [SerializeField] private ItemRarity _fillColor;

    private void OnEnable()
    {
        _playerItemStorage.ItemCountChange += UpdateSizeUI;
        UpdateSizeUI();
    }

    private void OnDisable()
    {
        _playerItemStorage.ItemCountChange -= UpdateSizeUI;
    }

    public void UpdateSizeUI()
    {
        SetFill();
        ChangeText();
    }

    public void SetFill()
    {
        float currentSlots = _playerItemStorage.CountItems - 1 - _playerItemStorage.NullSlots;
        float allSlots = _playerItemStorage.MaxSizeInventory;

        _fillIn.fillAmount = currentSlots / allSlots;
        Mathf.Clamp(_fillIn.fillAmount, 0, 1);

        if (_fillIn.fillAmount <= 0.33f)
            _fillIn.color = _fillColor.GetColor(0);
        else if(_fillIn.fillAmount > 0.33f && _fillIn.fillAmount <= 0.66f)
            _fillIn.color = _fillColor.GetColor(1);
        else if(_fillIn.fillAmount > 0.66f && _fillIn.fillAmount <= 0.99f)
            _fillIn.color = _fillColor.GetColor(2);
        else
            _fillIn.color = _fillColor.GetColor(3);
    }

    public void ChangeText()
    {
        _textCount.text = (_playerItemStorage.CountItems - 1 - _playerItemStorage.NullSlots).ToString() + "|" + _playerItemStorage.MaxSizeInventory;
    }
}
