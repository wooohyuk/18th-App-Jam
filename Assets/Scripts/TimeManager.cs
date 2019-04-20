using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        UIManager.Instance.SetTextTime(time);
        
        StartTimer();
    }
}
