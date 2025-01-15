// Copyright 2025 Muhammad Alhasan. All rights reserved.

using UnityEngine;

public class PinballFlicker2D : MonoBehaviour
{
	[Header("Flicker Settings")]
	public float flickAngle = 45f; // Maximum rotation angle
	public float flickSpeed = 10f; // Speed of rotation
	public Vector2 center;
	public KeyCode flickKey = KeyCode.Space; // Key to trigger the flick

	private Rigidbody2D rb;
	private float initialRotation; // Starting rotation angle
	private float targetRotation; // Target rotation angle


	private bool isFlicking = false;
	private float currentRotation;
	private float rotationSpeed;

	private void Start()
	{



		rb = GetComponent<Rigidbody2D>();

		if (rb == null)
		{
			Debug.LogError("Rigidbody2D component is missing! Please add a Rigidbody2D to this object.");
		}

		initialRotation = rb.rotation;
		targetRotation = initialRotation - flickAngle;
	}

   private void Update()
   {
      HandleFlicker();
      rb.centerOfMass = center;
   }

   private void HandleFlicker()
	{
		if (Input.GetKeyDown(flickKey) && !isFlicking)
		{
			StartFlick();
		}
	}
	private void StartFlick()
	{
		
			//isFlicking = false;
			currentRotation = rb.rotation;
			rotationSpeed = flickSpeed * 100;
			Flick();
	}

	void Flick()
	{
      //if (isFlicking) return;

		if (Mathf.Abs(currentRotation - targetRotation) > 0.1f)
		{
			// Rotate to the target angle
			currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
			rb.MoveRotation(currentRotation);
		}
		else if (Mathf.Abs(currentRotation - initialRotation) > 0.1f)
		{
			// Rotate back to the initial angle
			currentRotation = Mathf.MoveTowards(currentRotation, initialRotation, rotationSpeed * Time.deltaTime);
			rb.MoveRotation(currentRotation);
		}
		else
		{
			// End flicking
			isFlicking = false;
		}

	}
	//	void Flick()			//  System.Collections.IEnumerator Flick()
	//{
	//		isFlicking = true;

	//	// Rotate to the target angle
	//	if (Mathf.Abs(rb.rotation - targetRotation) > 0.1f)
	//	{
	//		float newRotation = Mathf.MoveTowards(rb.rotation, targetRotation, flickSpeed * Time.deltaTime * 100);
	//		rb.MoveRotation(newRotation);
	//		//yield return null;
	//	}

	//	// Rotate back to the initial angle
	//	else if (Mathf.Abs(rb.rotation - initialRotation) > 0.1f)
	//	{
	//		float newRotation = Mathf.MoveTowards(rb.rotation, initialRotation, flickSpeed * Time.deltaTime * 100);
	//		rb.MoveRotation(newRotation);
	//		//yield return null;
	//	}
	//		isFlicking = false;
	//}
}
