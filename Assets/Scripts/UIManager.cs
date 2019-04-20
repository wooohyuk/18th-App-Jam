using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text textStellar;
    public Text textTime;

    private void Awake()
    {
        if(UIManager.Instance == null)
            UIManager.Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetTextStellar(int stellar)
    {
        textStellar.text = stellar + " XLM";
    }

    public void SetTextTime(float time)
    {
        int hour = (int) System.Math.Truncate(time / 3600);
        int min = (int) System.Math.Truncate(time / 60 % 60);
        int sec = (int) System.Math.Truncate(time % 60);

        textTime.text = string.Format("{0}시간 {1}분 {2}초", hour, min, sec);
        
        Debug.Log(sec);
    }
}
