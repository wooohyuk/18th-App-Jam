using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public static MainSceneManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public MainSceneModes _mainSceneModes = MainSceneModes.None;

    public void changeMainSceneMode(MainSceneModes mode, bool toggle = true)
    {
        if (toggle)
        {
            if (_mainSceneModes != mode)
            {
                _mainSceneModes = mode;
            }
            else if (_mainSceneModes == mode)
            {
                _mainSceneModes = MainSceneModes.None;
            }
        }
        else
        {
            _mainSceneModes = mode;
        }
    }

    public void setMode_Clean()
    {
        changeMainSceneMode(MainSceneModes.Clean);
    }

    public void setMode_Feed()
    {
        changeMainSceneMode(MainSceneModes.Feed);
    }

    public void setMode_None()
    {
        changeMainSceneMode(MainSceneModes.None);
    }
}


public enum MainSceneModes
{
    Clean,
    Feed,
    None
}