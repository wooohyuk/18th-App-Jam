using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private List<ShopItem> listShopItem = new List<ShopItem>();
    private int shopItemIndex = 0;

    private void Start()
    {
        InitShopItem();
    }

    private void InitShopItem()
    {
        AddShopItem("개구리", 100);
        AddShopItem("너구리", 500);
        AddShopItem("딱다구리", 1000);
    }

    private void AddShopItem(string name, int cost)
    {
        listShopItem.Add(new ShopItem(){id = shopItemIndex++, cost = cost, name = name});
    }

    public void ShowBuy(int index)
    {
        
    }
}
