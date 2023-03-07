using UnityEngine;

public class TextShower : MonoBehaviour
{
    [SerializeField] private GameObject _helper;

    private void Start()
    {
        _helper.SetActive(false);
    }

    private void OnMouseEnter()
    {
        _helper.SetActive(true);
    }

    private void OnMouseExit()
    {
        _helper.SetActive(false);
    }
}
