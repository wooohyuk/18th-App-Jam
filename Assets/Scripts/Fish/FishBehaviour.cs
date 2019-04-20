using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class FishBehaviour : MonoBehaviour
{
	private Rigidbody2D rgBody;

	// Use this for initialization
	void Start ()
	{
		rgBody = GetComponent<Rigidbody2D>();
		StartCoroutine(PushEveryNSec());
	}

	// Update is called once per frame

	void Update () {

	}

	IEnumerator PushEveryNSec()
	{
		while (true)
		{
			yield return new WaitForSeconds(1.2f);
			pushToRandomDirection();
		}

	}

	float scale = 60f;

	void pushToRandomDirection()
	{
		Vector2 force = new Vector2(Random.Range(-1.0f, 1f) * scale, Random.Range(-1.0f, 1f)* scale);
		print(force);
		rgBody.AddForce(force);
	}
}
