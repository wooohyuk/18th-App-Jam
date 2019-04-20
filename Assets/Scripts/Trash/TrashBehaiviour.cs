using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TrashBehaiviour : MonoBehaviour
{
	public GameObject bubblePrefab;
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private float targetDragTime = 3f;
	private float dragingTime = 0.1f;

	private float dragTimePercent
	{
		get { return dragingTime / targetDragTime; }
	}

	int bubbleInterval = 0;
	private void OnMouseDrag()
	{
		if (MainSceneManager.Instance._mainSceneModes == MainSceneModes.Clean)
		{
			if (targetDragTime > dragingTime)
			{
				dragingTime += Time.deltaTime;
				Color tmp = spriteRenderer.color;
				tmp.a = 1 - dragTimePercent;
				spriteRenderer.color = tmp;
				if (bubbleInterval % 500 == 0)
				{
					createBubble();
				}
				bubbleInterval += 1;
			}
			else
			{
				createBubble();
				Destroy(gameObject, 1);
			}
		}
	}


	void createBubble()
	{
		var obj = Instantiate(bubblePrefab, this.transform.position, Quaternion.identity);
		obj.transform.parent = transform;
		obj.transform.localScale = new Vector3(0.05f, 0.05f, 1);
		Destroy(obj, 10);
	}
}
