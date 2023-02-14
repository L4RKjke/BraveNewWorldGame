using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintController : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Hint _hint;

    private List<GameObject> _hints = new List<GameObject>() { };

    private void OnEnable()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            var buttonId = i;
            _buttons[i].onClick.AddListener(() => Hide(buttonId));
            _hints.Add(Instantiate(_hint.transform.gameObject, new Vector2(_buttons[i].transform.position.x, _buttons[i].transform.position.y), Quaternion.identity) as GameObject);
            _hints[i].transform.SetParent(_buttons[i].transform);
            _hints[i].transform.localPosition = new Vector2 (28f, 30f);
            _hints[i].transform.localScale = new Vector2(0.7f, 0.7f);
            _hints[i].SetActive(false);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].onClick.RemoveListener(() => Hide(i));
        }
    }

    public void ActivateHint(Button button)
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (_buttons[i] == button)
                _hints[i].SetActive(true);
        }
    }

    private void Hide(int id)
    {
        _hints[id].SetActive(false);
    }
}
