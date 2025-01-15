// Copyright 2025 Muhammad Alhasan. All rights reserved.

using UnityEngine;

public class NewFlick : MonoBehaviour
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
   private bool rotatingToTarget = false; // Track if rotating to the target or returning
   private float currentRotation;

   private void Start()
   {
      rb = GetComponent<Rigidbody2D>();

      if (rb == null)
      {
         Debug.LogError("Rigidbody2D component is missing! Please add a Rigidbody2D to this object.");
      }

      initialRotation = rb.rotation;
      targetRotation = initialRotation - flickAngle;
      currentRotation = initialRotation;
   }

   private void Update()
   {
      HandleFlicker();
      rb.centerOfMass = center;

      if (isFlicking)
      {
         FlickLogic();
      }
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
      isFlicking = true;
      rotatingToTarget = true; // Start by rotating to the target angle
   }

   private void FlickLogic()
   {
      if (rotatingToTarget)
      {
         // Rotate to the target angle
         currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, flickSpeed * Time.deltaTime * 100);
         rb.MoveRotation(currentRotation);

         if (Mathf.Abs(currentRotation - targetRotation) <= 0.1f)
         {
            // Switch to rotating back to the initial angle
            rotatingToTarget = false;
         }
      }
      else
      {
         // Rotate back to the initial angle
         currentRotation = Mathf.MoveTowards(currentRotation, initialRotation, flickSpeed * Time.deltaTime * 100);
         rb.MoveRotation(currentRotation);

         if (Mathf.Abs(currentRotation - initialRotation) <= 0.1f)
         {
            // End flicking
            isFlicking = false;
         }
      }
   }
}
