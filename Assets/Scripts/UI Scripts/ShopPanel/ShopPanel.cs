using TMPro;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _money;

    private void OnEnable()
    {
        _player.CoinCountChanged += ChangeMoney;
        _money.text = _player.Coins.ToString();
    }

    private void OnDisable()
    {
        _player.CoinCountChanged -= ChangeMoney;
    }

    private void ChangeMoney(float newAmount) 
    { 
        _money.text = newAmount.ToString();
    }
}