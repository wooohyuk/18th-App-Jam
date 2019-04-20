using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TrashBehaiviour : MonoBehaviour
{
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
	private void OnMouseDrag()
	{
		if (targetDragTime > dragingTime)
		{
			dragingTime += Time.deltaTime;
			Color tmp = spriteRenderer.color;
			tmp.a = 1 - dragTimePercent;
			spriteRenderer.color = tmp;
		}
		else
		{
			Destroy(this);
		}
	}
}
