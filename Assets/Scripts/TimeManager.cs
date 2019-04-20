using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    [SerializeField]
    private float time = 0;

    private void Awake()
    {
        if(TimeManager.Instance == null)
            TimeManager.Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(CorTimer());
    }

    private IEnumerator CorTimer()
    {
        yield return new WaitForSeconds(.01f);
        time += 2.8f; // 288s

        int percent = (int) ((time / 86400) * 100);
        if(percent != 0 && percent % 20 == 0)
        {
            if(percent / 20 > GameManager.Instance.progress)
            {
                GameManager.Instance.progress ++;
                UIManager.Instance.ShowNewstory();
            }
        }

        UIManager.Instance.SetTextTime(time);
        
        StartTimer();
    }
}
