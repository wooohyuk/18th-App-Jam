using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInputManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    public Camera camera;
    Ray2D ray;
    RaycastHit2D hit;
    public GameObject prefab;

    void Update()
    {
        if (MainSceneManager.Instance._mainSceneModes == MainSceneModes.Feed)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 5f;

            Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Vector2 position = new Vector2(v.x, v.y);
                GameObject obj = Instantiate(prefab,
                    position,
                    Quaternion.identity);
                obj.transform.position = position;
            }
        }
    }
}