using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private Button _shopButton;

    private void OnEnable()
    {
        _shopButton.onClick.AddListener(ShowOrHideShop);
    }

    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(ShowOrHideShop);
    }

    private void ShowOrHideShop() 
    {
        if (_shopPanel.gameObject.activeSelf == false)
        {
            _shopPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else 
        {
            _shopPanel.SetActive(false);
            Time.timeScale = 1f;
        }       
    }
}
