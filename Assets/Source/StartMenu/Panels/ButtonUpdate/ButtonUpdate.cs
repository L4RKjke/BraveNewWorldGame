using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _priceUpdate;
    private PlayerWallet _wallet;

    public UnityAction Updated;

    public Button Button => this.GetComponent<Button>();

    private void Start()
    {
        _text.text = _priceUpdate.ToString();
    }

    private void OnEnable()
    {
        if (_wallet.Gold >= _priceUpdate)
        {
            _text.color = Color.white;
        }
    }

    public void Init(int price, PlayerWallet wallet)
    {
        _priceUpdate = price;
        _wallet = wallet;
        enabled = true;
    }

    public bool CheckCanUpdate()
    {
        bool canUpdate = false;

        if (_wallet.Gold >= _priceUpdate)
        {
            _text.color = Color.white;
            canUpdate = true;
            Updated?.Invoke();
        }
        else
        {
            string noMoney = "NoMoney";
            this.GetComponent<Animator>().SetTrigger(noMoney);
        }

        return canUpdate;
    }
}
