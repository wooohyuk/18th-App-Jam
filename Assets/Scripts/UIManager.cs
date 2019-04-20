using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text textStellar;
    public Text textTime;
    public Text textProgress;

    public GameObject btnNewstory;

    public GameObject imageTalk;
    public Text textTalk;

    public GameObject panelShop;
    public GameObject panelShopItemContent;

    private void Awake()
    {
        if(UIManager.Instance == null)
            UIManager.Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowShop()
    {
        panelShop.SetActive(true);
    }

    public void ShowNewstory()
    {
        btnNewstory.SetActive(true);
        btnNewstory.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        StartCoroutine(CorShowNewstory());
    }

    IEnumerator CorShowNewstory()
    {
        for(int i=0; i<100; i++)
        {
            yield return new WaitForSeconds(.01f);
            btnNewstory.GetComponent<Image>().color = new Color(1, 1, 1, btnNewstory.GetComponent<Image>().color.a + 0.01f);
        }
    }

    public void HideNewstory()
    {
        btnNewstory.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        StartCoroutine(CorHideNewstory());
    }

    IEnumerator CorHideNewstory()
    {
        for(int i=0; i<100; i++)
        {
            yield return new WaitForSeconds(.01f);
            btnNewstory.GetComponent<Image>().color = new Color(1, 1, 1, btnNewstory.GetComponent<Image>().color.a - 0.01f);
        }
        btnNewstory.SetActive(false);
    }

    public void SetTextStellar(int stellar)
    {
        textStellar.text = stellar.ToString();
    }

    public void SetTextTime(float time)
    {
        int hour = (int) System.Math.Truncate(time / 3600);
        int min = (int) System.Math.Truncate(time / 60 % 60);
        int sec = (int) System.Math.Truncate(time % 60);

        float percent = (time / 86400) * 100;

        textProgress.text = string.Format("연못 진척도 - " + percent.ToString("N2") + "%");
        // Debug.Log("연못 진척도 - " + percent + "%");
        
        // textTime.text = string.Format("{0}시간 {1}분 {2}초", hour, min, sec);
        
        // Debug.Log(sec);
    }
}
