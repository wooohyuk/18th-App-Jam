using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class StoryData
{
    private int index;
    private string message;

    public void SetStory(int index, string message)
    {
        this.index = index;
        this.message = message;
    }
}