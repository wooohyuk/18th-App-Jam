﻿using System;
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
			yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
			pushToRandomDirection(scale);
		}

	}

	public float scale = 12f;
	public float scaleBig = 22f;

	void pushToRandomDirection(float scale)
	{
		float x = Random.Range(-1.0f, 1f) * scale;
		Vector2 force = new Vector2(x, Random.Range(-1.0f, 1f)* scale/5);
		bool flipX = x < 0;
		_spriteRenderer.flipX = flipX;
		rgBody.AddForce(force);
	}

	private int eatCount = 0;
	public void feed(int i)
	{
		eatCount += i;
	}

	void OnMouseDown()
	{
		pushToRandomDirection(scaleBig);

	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Food"))
		{
			this.feed(1);
			Destroy(other.gameObject);
		}
	}
}
