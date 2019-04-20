using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class FishBehaviour : MonoBehaviour
{
	private Rigidbody2D rgBody;

	private SpriteRenderer _spriteRenderer;
	// Use this for initialization
	void Start ()
	{
		rgBody = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		StartCoroutine(PushEveryNSec());
	}

	// Update is called once per frame


	IEnumerator PushEveryNSec()
	{
		while (true)
		{
			yield return new WaitForSeconds(1.2f);
			pushToRandomDirection();
		}

	}

	public float scale = 12f;

	void pushToRandomDirection()
	{
		float x = Random.Range(-1.0f, 1f) * scale;
		Vector2 force = new Vector2(x, Random.Range(-1.0f, 1f)* scale/5);
		bool flipX = x > 0;
		_spriteRenderer.flipX = flipX;
		rgBody.AddForce(force);
	}
}
