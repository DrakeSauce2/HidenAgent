using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemWidget : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI price;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] Button buyButton;
    public Button BuyButton { get { return buyButton; } }
    [Space]
    [SerializeField] GameObject grayOutBox;
    [SerializeField] Color grayOutColor;
    [SerializeField] Color normalColor;

    public ShopItem item { get; private set; }
    private CreditComponent playerCreditComp;

    internal void Init(ShopItem item, int credits)
    {
        this.item = item;

        icon.sprite = item.Icon;
        itemName.text = item.Title;
        price.text = $"${item.Price}";
        description.text = item.Description;

        Refresh(credits);
    }

    public void Refresh(int newCredit)
    {
        if (newCredit < item.Price)
        {
            grayOutBox.SetActive(true);
            price.color = grayOutColor;
        }
        else
        {
            grayOutBox.SetActive(false);
            price.color = normalColor;
        }
    }
}
