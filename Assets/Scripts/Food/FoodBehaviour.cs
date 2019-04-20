using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FoodBehaviour : MonoBehaviour
{
	private Rigidbody2D rgBody;
	// Use this for initialization
	void Start ()
	{
		rgBody = GetComponent<Rigidbody2D>();
		StartCoroutine(fallWithMoving());
	}

	private bool isForceToLeft = true;
	
	// Update is called once per frame
	private float forceScale = 30;
	private float waitFor = 0.5f;
	IEnumerator fallWithMoving()
	{
		while (true)
		{
			int direction = isForceToLeft ? -1 : 1;
			Vector2 force = new Vector2(direction * forceScale, 0);
			rgBody.AddForce(force);
			yield return new WaitForSeconds(waitFor);
			isForceToLeft = !isForceToLeft;
		}
	}
}
