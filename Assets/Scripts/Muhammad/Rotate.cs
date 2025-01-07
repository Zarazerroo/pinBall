// Copyright 2025 Muhammad Alhasan. All rights reserved.

using UnityEngine;

public class Rotate : MonoBehaviour
{

	public float speed = 10f;

	Rigidbody2D rb;


	void Start()
	{
			rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		rb.rotation += speed * Time.fixedDeltaTime;
	}
}
