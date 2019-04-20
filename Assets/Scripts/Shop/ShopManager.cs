using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    public GameObject prefabItem;

    private List<ShopItem> listShopItem = new List<ShopItem>();
    private int shopItemIndex = 0;

    private void Awake()
    {
        if(ShopManager.Instance == null)
            ShopManager.Instance = this;
        else
            Destroy(gameObject);
    }


    private void Start()
    {
        InitShopItem();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.A))
            ShowItems(1);

        if(Input.GetKeyDown(KeyCode.S))
            ShowItems(2);
    }

    private void InitShopItem()
    {
        AddShopItem("개구리", 1, 100);
        AddShopItem("너구리", 1, 500);
        AddShopItem("딱다구리", 1, 1000);

        AddShopItem("귀여운 팡무", 2, 1000);
        AddShopItem("아름다운 팡무", 2, 5000);
        AddShopItem("리미티드 섹시한 팡무", 2, 10000);

        AddShopItem("탄산수", 3, 500);
        AddShopItem("칠성 사이다", 3, 1000);
        AddShopItem("스프라이트", 3, 1500);
        AddShopItem("환타", 3, 2000);
        AddShopItem("펩시", 3, 2500);
        AddShopItem("코카콜라", 3, 3000);
        AddShopItem("핫식스", 3, 4000);
        AddShopItem("레드불", 3, 5000);
        AddShopItem("몬스터", 3, 6000);
    }

    public void ShowItems(int type)
    {
        for(int i=0; i<UIManager.Instance.panelShopItemContent.transform.childCount; i++)
        {
            Destroy(UIManager.Instance.panelShopItemContent.transform.GetChild(i).gameObject);
        }

        for(int i=0; i<listShopItem.Count; i++)
        {
            if(listShopItem[i].type == type)
            {
                GameObject obj = Instantiate(prefabItem);
                obj.transform.parent = UIManager.Instance.panelShopItemContent.transform;

                // obj.transform.Find("Text Item Name").GetComponent<Text>().text = listShopItem[i].itemName;

                obj.GetComponent<ShopItemController>().id = listShopItem[i].id;
                obj.GetComponent<ShopItemController>().itemName = listShopItem[i].itemName;
                obj.GetComponent<ShopItemController>().cost = listShopItem[i].cost;

                Debug.Log(listShopItem[i].id + " / " + listShopItem[i].itemName);
            }
        }
    }

    private void AddShopItem(string itemName, int type, int cost)
    {
        listShopItem.Add(new ShopItem() {
            id = shopItemIndex++, type = type, cost = cost, itemName = itemName
        });
    }

    public void BuyItem(int id)
    {
        int cost = listShopItem[id].cost;
        if(cost <= GameManager.Instance.GetStellar())
        {
            // Item Buy
            GameManager.Instance.DecreaseStellar(cost);
        }
    }
}
