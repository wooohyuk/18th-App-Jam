using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public List<EventData> listEvent = new List<EventData>();
    private int eventIndex = 0;

    public bool isShow = false;

    private void Start()
    {
        InitEvent();

        StartCheckEvent();
    }

    private void InitEvent()
    {
        AddEvent("물주기", "저 친구도 목이 마른 것 같구나");
        AddEvent("밥주기", "물고기 친구들이 배가 고플 것 같구나");
        AddEvent("물속청소", "깊은 곳에 청소가 필요해 보이는 것 같구나");
        AddEvent("바깥청소", "연못이 답답해 보이는 구나");
        AddEvent("침입자", "심술궂은 친구가 찾아왔구나");
        AddEvent("수위높음", "연못 친구 다이어트 좀 해야겠는걸?");
        AddEvent("수위낮음", "연못이 배가 고픈 것 같구나 하 하 하");

        AddEvent("Fuck", "여기 살아있는 모든 것들은 아빠와 함께 컸단다");
        AddEvent("Fuck", "물고기에게 밥을 너무 많이 주면 안돼");
        AddEvent("Fuck", "언제와도 좋구나");
        AddEvent("Fuck", "예전엔 두루미도 있었는데");
        AddEvent("Fuck", "연못에 새 친구가 필요한 것 같은데?");
        AddEvent("Fuck", "사슴 가족은 우리 가족보다 여기 오래 살았어");
        AddEvent("Fuck", "할아버지도 물을 무서워 하셨지 하 하 하 하");
        AddEvent("Fuck", "새들은 난폭해, 물고기들을 지켜줘야 한단다");
        AddEvent("Fuck", "가끔은 생각한단다. 연못이 우리를 기다리고 있던 게 아닐까?");
        AddEvent("Fuck", "어때 물도 나름 괜찮지?");
    }

    private void AddEvent(string title, string context)
    {
        listEvent.Add(new EventData() {
            id = eventIndex++, eventTitle = title, eventContext = context
        });
    }

    public void ShowEvent(int type, int id)
    {        
        if(type == 1)
        {
            if(id == 0)
                UIManager.Instance.ShowDeer();
        }
        else
        {
            
        }
        StartCoroutine(CorHideEvent());
    }

    IEnumerator CorHideEvent()
    {
        yield return new WaitForSeconds(3f);

        for(int i=0; i<100; i++)
        {
            yield return new WaitForSeconds(.01f);
            UIManager.Instance.imageTalk.GetComponent<Image>().color = new Color(1, 1, 1, UIManager.Instance.imageTalk.GetComponent<Image>().color.a - 0.01f);
        }

        UIManager.Instance.imageTalk.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        UIManager.Instance.imageTalk.SetActive(false);

        isShow = false;

        StartCheckEvent();
    }

    private void StartCheckEvent()
    {
        StopCoroutine(CorCheckEvent());
        StartCoroutine(CorCheckEvent());
    }

    IEnumerator CorCheckEvent()
    {
        yield return new WaitForSeconds(2f);

        int rand = Random.Range(1, 101);
        Debug.Log(rand);

        if(rand > 0 && rand <= 40)
        {
            UIManager.Instance.imageTalk.SetActive(true);
            UIManager.Instance.imageTalk.GetComponent<Image>().color = new Color(1, 1, 1, 0);

            int randEvent = Random.Range(0, 18); // 0 ~ 7 / 7 ~ 17
            UIManager.Instance.textTalk.text = listEvent[randEvent].eventContext;

            for(int i=0; i<100; i++)
            {
                yield return new WaitForSeconds(.01f);
                UIManager.Instance.imageTalk.GetComponent<Image>().color = new Color(1, 1, 1, UIManager.Instance.imageTalk.GetComponent<Image>().color.a + 0.01f);
            }

            if(randEvent > 7)
                ShowEvent(1, randEvent);
            else
                ShowEvent(2, randEvent);
        }
        else
            StartCheckEvent();
    }
}