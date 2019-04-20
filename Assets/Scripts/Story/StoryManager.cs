using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    private List<StoryData> listStoryData = new List<StoryData>();
    private int storyIndex = 1;

    private void Start()
    {
        
    }

    private void InitStory()
    {
        // AddStroy(storyIndex++, "우에");
    }

    private void AddStroy(int index, string message)
    {
        listStoryData.Add(new StoryData() {index = index, message = message});
    }
}
