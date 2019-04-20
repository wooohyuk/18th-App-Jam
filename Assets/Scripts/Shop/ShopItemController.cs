using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemController : MonoBehaviour
{
    public int id;
    public int cost;

    public string itemName;

    public Text textItemName;
    public Text textCost;

    private void Start()
    {
        textItemName.text = itemName;
        textCost.text = cost.ToString();
    }
    
    public void BuyItem()
    {
        if(cost <= GameManager.Instance.GetStellar())
        {
            // Item Buy
            GameManager.Instance.DecreaseStellar(cost);
        }
    }
}
