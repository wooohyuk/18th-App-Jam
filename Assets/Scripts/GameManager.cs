using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private int stellar = 0;

    public int progress = 0;

    public GameObject canvas;
    public GameObject uiCamera;

    private void Awake()
    {
        if(GameManager.Instance == null)
            GameManager.Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            uiCamera.SetActive(true);
            HideCanvas();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            uiCamera.SetActive(false);
            ShowCanvas();
        }
    }

    public void ShowCanvas()
    {
        canvas.SetActive(true);
    }

    public void HideCanvas()
    {
        canvas.SetActive(false);
    }

    public int GetStellar()
    {
        return stellar;
    }

    public void SetStellar(int ammount)
    {
        stellar = ammount;

        UIManager.Instance.SetTextStellar(stellar);
    }

    public void IncreaseStellar(int ammount)
    {
        stellar += ammount;

        UIManager.Instance.SetTextStellar(stellar);
    }

    public void DecreaseStellar(int ammount)
    {
        stellar -= ammount;
    }
}
