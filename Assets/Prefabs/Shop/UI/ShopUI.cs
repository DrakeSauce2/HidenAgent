using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] Shop shop;
    [SerializeField] ShopItemWidget itemWidgetPrefab;
    [SerializeField] Transform shopList;
    [SerializeField] CreditComponent creditComponent;
    [SerializeField] Button buyButton;

    List<ShopItemWidget> shopItemWidgets = new List<ShopItemWidget>();

    private void Awake()
    { 
        foreach (ShopItem item in shop.GetItems())
        {
            ShopItemWidget newWidget = Instantiate(itemWidgetPrefab, shopList);
            newWidget.Init(item, creditComponent.Credits);

            newWidget.BuyButton.onClick.AddListener(() => shop.SetSelectedItem(newWidget));

            shopItemWidgets.Add(newWidget);
        }

        buyButton.onClick.AddListener(() => shop.BuyItem());

        creditComponent.onCreditChanged += RefreshItems;
    }

    private void RefreshItems(int newCredit)
    {
        foreach (ShopItemWidget item in shopItemWidgets)
        {
            item.Refresh(newCredit);
        }
    }



}
