using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Assistant : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TMPro;
    [SerializeField] private GameObject _assistant;
    [SerializeField] private Button _tapToContinue;

    private void OnEnable()
    {
        _tapToContinue.onClick.AddListener(() => Hide());
    }

    private void OnDisable()
    {
        _tapToContinue.onClick.RemoveListener(() => Hide());
    }

    public void ActivateAssistant(Task task)
    {
        _assistant.SetActive(true);
        _TMPro.text = task.Destription;
    }

    private void Hide()
    {
        _assistant.SetActive(false);
    }
}
