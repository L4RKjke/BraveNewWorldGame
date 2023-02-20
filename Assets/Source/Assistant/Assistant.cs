using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Assistant : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TMPro;
    [SerializeField] private GameObject _assistant;
    [SerializeField] private Button _tapToContinue;

    private Coroutine _textRoutine;

    private void OnEnable()
    {
        _tapToContinue.onClick.AddListener(() => Hide());
    }

    private void OnDisable()
    {
        _tapToContinue.onClick.RemoveListener(() => Hide());

        if (_textRoutine != null)
            StopCoroutine(_textRoutine);
    }

    public void ActivateAssistant(Task task)
    {
        _assistant.SetActive(true);

        if (_textRoutine != null)
            StopCoroutine(_textRoutine);

        _textRoutine = StartCoroutine(ShowText(task.Destription));
    }

    private void Hide()
    {
        _assistant.SetActive(false);
    }

    private IEnumerator ShowText(string text)
    {
        float delay = 0.015f;
        int index = 0;

        _TMPro.text = "";

        while (index < text.Length)
        {
            yield return new WaitForSeconds(delay);

            _TMPro.text += text[index++];
        }
    }
}
