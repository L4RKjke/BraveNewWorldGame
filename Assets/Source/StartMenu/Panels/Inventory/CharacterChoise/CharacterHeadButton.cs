using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CharacterHeadButton : MonoBehaviour
{
    [SerializeField] private GameObject _headAnchor;
    [SerializeField] private Image _chosed;
    [SerializeField] private Image _ribbon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _circle;
    [SerializeField] private TMP_Text _level;

    public Image Circle => _circle;

    public void SetCircle(Sprite circle)
    {
        _circle.sprite = circle;
    }

    public void ChoisedChange(bool _isOn)
    {
        _chosed.enabled = _isOn;
    }

    public void SetHead(GameObject head)
    {
        UpdateCharactersIcon(_headAnchor, head);
    }

    public void SetNameAndLevel(string name, int level)
    { 
        _name.text = name;
        _level.text = level.ToString();
    }

    private void UpdateCharactersIcon(GameObject buttonHead, GameObject head, int id = 0)
    {
        AddSprite(buttonHead, head, 0);

        for (int i = 0; i < head.transform.GetChild(id).childCount; i++)
        {
            AddSprite(buttonHead.transform.GetChild(id).gameObject, head.transform.GetChild(id).gameObject, i);
            UpdateCharactersIcon(buttonHead.transform.GetChild(id).gameObject, head.transform.GetChild(id).gameObject, i);
        }
    }

    private void AddSprite(GameObject objectIMG, GameObject objectSprite, int id)
    {
        objectIMG.transform.GetChild(id).TryGetComponent(out Image tempIMG);
        objectSprite.transform.GetChild(id).TryGetComponent(out SpriteRenderer tempSprite);
        tempIMG.sprite = tempSprite.sprite;
        tempIMG.color = tempSprite.color;

        if (objectSprite.transform.GetChild(id).GetComponent<SpriteRenderer>().sprite == null)
            tempIMG.color = new Color(tempIMG.color.r, tempIMG.color.g, tempIMG.color.b, 0);

        tempIMG.enabled = tempSprite.enabled;
    }
}
