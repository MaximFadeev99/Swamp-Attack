using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductCard : MonoBehaviour
{
    private const string PurchaseButton = nameof(PurchaseButton);
    private const string ImageField = nameof(ImageField);
    private const string DescriptionField = nameof(DescriptionField);
    private const string PriceField = nameof(PriceField);
    private const string BoughtImage = nameof(BoughtImage);

    private Weapon _product;
    private Image _mainImage;
    private Image _boughtImage;
    private TextMeshProUGUI _descriptionField;
    private TextMeshProUGUI _priceField;
    private Player _player;
    private Button _puchaseButton;
    
    private void Awake()
    {
        _player = FindFirstObjectByType<Player>();
        _puchaseButton = transform.Find(PurchaseButton).GetComponent<Button>();
        _mainImage = transform.Find(ImageField).GetComponent<Image>();
        _descriptionField = transform.Find(DescriptionField).GetComponent<TextMeshProUGUI>();
        _priceField = transform.Find(PriceField).GetComponent<TextMeshProUGUI>();
        _boughtImage = transform.Find(BoughtImage).GetComponent<Image>();
        _boughtImage.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _puchaseButton.onClick.AddListener(OnPurchaseButtonClick);
    }

    private void OnDisable()
    {
        _puchaseButton.onClick.RemoveListener(OnPurchaseButtonClick);
    }

    private void OnPurchaseButtonClick() 
    {
        if(_player.Coins >= _product.Price) 
        {
            _player.ActivateItem(_product);
            _puchaseButton.gameObject.SetActive(false);
            _boughtImage.gameObject.SetActive(true);
        }       
    }

    public void Render(Weapon product)
    {
        _product = product;
        _mainImage.sprite = product.Icon;
        _descriptionField.text = product.Description;
        _priceField.text = product.Price.ToString();
    }
}