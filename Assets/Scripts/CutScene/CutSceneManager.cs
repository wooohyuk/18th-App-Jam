using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager Instance;
    public List<Sprite> datas;
    public Image image;
    private void Awake()
    {
        Instance = this;
    }


    public int currentCut = 0;
    public void setCutScene(int i)
    {
        try
        {
            var sprite = datas[i];
            image.sprite = sprite;
//        _image.image = sprite;
            currentCut = i;
        }
        catch (Exception e)
        {

        }

    }

    public void playNext()
    {
        currentCut += 1;
        setCutScene(currentCut);
    }

    public void closePanel()
    {
        enabled = false;
    }

    public void openPanel()
    {
        enabled = true;
    }

}
