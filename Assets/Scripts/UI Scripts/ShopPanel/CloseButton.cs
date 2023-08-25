using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(HideShop); 
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(HideShop);
    }

    private void HideShop() 
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}