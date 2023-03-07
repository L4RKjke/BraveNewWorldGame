using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterPanelView : MonoBehaviour
{
    [SerializeField] private Image _monster;
    [SerializeField] private TMP_Text _count;

    public void Init(Sprite monster, int count)
    {
        _monster.sprite = monster;
        _count.text = " X " + count.ToString();
    }
}
