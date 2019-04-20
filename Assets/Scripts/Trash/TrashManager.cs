using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public static TrashManager Instance;

    public List<GameObject> prefabTrash = new List<GameObject>();

    private void Awake()
    {
        if(TrashManager.Instance == null)
            TrashManager.Instance = this;
        else
            Destroy(gameObject);
    }

    public void CreateTrash(int type)
    {
        GameObject obj = Instantiate(prefabTrash[type]);
        obj.transform.position = new Vector2(0, 0);

        
    }
}
