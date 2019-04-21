using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text textStellar;
    public Text textTime;
    public Text textProgress;

    public Image imgDeer;

    public GameObject btnNewstory;

    public GameObject imageTalk;
    public Text textTalk;

    public GameObject panelShop;
    public GameObject panelShopItemContent;

    public GameObject panelShop2;

    public Sprite[] imageBG = new Sprite[5];
    public GameObject spriteBg;

    public SpriteRenderer spriteFish1;
    public SpriteRenderer spriteFish2;
    public SpriteRenderer spriteFish3;

    private void Awake()
    {
        if(UIManager.Instance == null)
            UIManager.Instance = this;
        else
            Destroy(gameObject);
    }    

    private void Start() {
        StartCoroutine(CorFadeFish1());
        StartCoroutine(CorFadeFish2());
        StartCoroutine(CorFadeFish3());
    }

    IEnumerator CorFadeFish1()
    {
        spriteFish1.color = new Color(1, 1, 1, 0);

        for(int i=1; i<=100; i++)
        {
            spriteFish1.color = new Color(1, 1, 1, spriteFish1.color.a + .01f);
            yield return new WaitForSeconds(.05f);
        }

        for(int i=1; i<=100; i++)
        {
            spriteFish1.color = new Color(1, 1, 1, spriteFish1.color.a - .01f);
            yield return new WaitForSeconds(.05f);
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(CorFadeFish1());
    }

    IEnumerator CorFadeFish2()
    {
        spriteFish2.color = new Color(1, 1, 1, 1);

        for(int i=1; i<=100; i++)
        {
            spriteFish2.color = new Color(1, 1, 1, spriteFish2.color.a - .01f);
            yield return new WaitForSeconds(.1f);
        }

        for(int i=1; i<=100; i++)
        {
            spriteFish2.color = new Color(1, 1, 1, spriteFish2.color.a + .01f);
            yield return new WaitForSeconds(.1f);
        }

        yield return new WaitForSeconds(3f);
        StartCoroutine(CorFadeFish2());
    }

     IEnumerator CorFadeFish3()
    {
        spriteFish3.color = new Color(1, 1, 1, 0);

        for(int i=1; i<=100; i++)
        {
            spriteFish3.color = new Color(1, 1, 1, spriteFish3.color.a + .01f);
            yield return new WaitForSeconds(.03f);
        }

        for(int i=1; i<=100; i++)
        {
            spriteFish3.color = new Color(1, 1, 1, spriteFish3.color.a - .01f);
            yield return new WaitForSeconds(.03f);
        }

        yield return new WaitForSeconds(4f);

        StartCoroutine(CorFadeFish1());
    }

    public void GoDeep()
    {
        SceneFader.instance.LoadSceneWhenFadingComplete(SceneType.Main);
    }

    public void ShowDeer()
    {
        StartCoroutine(CorShowDeer());
    }

    public void HideDeer()
    {
        StartCoroutine(CorHideDeer());
    }

    public void NextBg(int index)
    {
        Debug.Log(index);
        spriteBg.GetComponent<SpriteRenderer>().sprite = imageBG[2];
    }

    IEnumerator CorShowDeer()
    {
        imgDeer.color = new Color(1, 1, 1, 0);
        for(int i=0; i<100; i++)
        {
            yield return new WaitForSeconds(.01f);
            imgDeer.color = new Color(1, 1, 1, imgDeer.color.a + 0.01f);
        }
        imgDeer.color = new Color(1, 1, 1, 1);
    }

    IEnumerator CorHideDeer()
    {
        for(int i=0; i<100; i++)
        {
            yield return new WaitForSeconds(.01f);
            imgDeer.color = new Color(1, 1, 1, imgDeer.color.a - 0.01f);
        }
        imgDeer.color = new Color(1, 1, 1, 0);
    }

    public void ShowShop()
    {
        panelShop.SetActive(true);
    }

    public void ShowShop2()
    {
        panelShop2.SetActive(true);
    }

    public void HideShop2()
    {
        panelShop2.SetActive(false);
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

        TimeManager.Instance.isStop = false;
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
