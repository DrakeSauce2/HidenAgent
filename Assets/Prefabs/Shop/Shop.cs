using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Shop")]
public class Shop : ScriptableObject
{
    [SerializeField] ShopItem[] items;

    private ShopItemWidget selectedWidget;

    public bool TryPurchase(ShopItem item, CreditComponent buyer)
    {
        return buyer.TryPurchaseItem(item);
    }

    public void SetSelectedItem(ShopItemWidget itemWidget)
    {
        selectedWidget = itemWidget;
    }

    public void BuyItem()
    {
        if (selectedWidget == null) return;

        if(TryPurchase(selectedWidget.item, GameplayStatics.GetPlayerGameObject().GetComponent<CreditComponent>()))
        {
            Destroy(selectedWidget.gameObject);
        }
    }

    public ShopItem[] GetItems()
    {
        return items;
    }

}
