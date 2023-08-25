using System.Collections.Generic;
using UnityEngine;

public class ContentFiller : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private ProductCard _productCard;

    private void Awake()
    {      
        foreach (Weapon weapon in _weapons) 
        {
            InstantiateAndRender(weapon);          

            if (weapon.TryGetComponent(out Bow bow)) 
                InstantiateAndRender(bow.Arrow);
        }
    }

    private void InstantiateAndRender(Weapon weapon) 
    {
        ProductCard productCard;

        productCard = Instantiate(_productCard, transform);
        productCard.Render(weapon);
        weapon.IsBought = false;
    }
}
