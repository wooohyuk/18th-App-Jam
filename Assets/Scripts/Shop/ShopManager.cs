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
        // 박지 물고기 1 - 포포
        // 박지 물고기 2 - 셸리
        // 박지 물고기 3 - 치치
        // 박지 물고기 4 - 그랑
        // 박지 물고기 5 - 배런
        // 박지 물고기 6 - 레드
        // 박지 물고기 7 - 옐로우
        // 영어 물고기 블루 - 우정
        // 영어 물고기 오렌 - 희망
        // 영어 물고기 핑크 - 사랑
        // 영어 물고기 퍼플 - 믿음
        AddShopItem("포포", 1, 100);
        AddShopItem("셀리", 1, 400);
        AddShopItem("치치", 1, 900);
        AddShopItem("그랑", 1, 1600);
        AddShopItem("배런", 1, 2300);
        AddShopItem("레드", 1, 3900);
        AddShopItem("옐로우", 1, 4700);
        AddShopItem("우정", 1, 5900);
        AddShopItem("희망", 1, 8200);
        // AddShopItem("사랑", 1, 12600);
        // AddShopItem("믿음", 1, 16700);

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
        
        ShowItems(1);
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
