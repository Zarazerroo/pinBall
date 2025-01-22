// Copyright 2025 Muhammad Alhasan. All rights reserved.

using UnityEngine;
public class TP : MonoBehaviour
{

	public Vector2 TP_end = new Vector2();

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Ball"))
		{
			other.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
			other.transform.position = TP_end;
		}
	}
}
