// All rights reserved � 2025 Muhammad Alhasan. Unauthorized copying, distribution, or modification is prohibited.

using UnityEngine;

public class PinballFlicker2D : MonoBehaviour
{
   AudioManager audioManager;

   [Header("Flicker Settings")]
   public float flickAngle = 45f; // Maximum rotation angle
   public float flickSpeed = 10f; // Speed of rotation
   public Vector2 center;
   public KeyCode flickKey = KeyCode.Space; // Key to trigger the flick

   private Rigidbody2D rb;
   private float initialRotation; // Starting rotation angle
   private float targetRotation; // Target rotation angle
   private bool isFlicking = false;

   private void Awake()
   {
      audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
   }

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
         StartCoroutine(Flick());

         audioManager.PlaySFX(audioManager.flippers);
      }
   }

   private System.Collections.IEnumerator Flick()
   {
      isFlicking = true;

      // Rotate to the target angle
      while (Mathf.Abs(rb.rotation - targetRotation) > 0.1f)
      {
         float newRotation = Mathf.MoveTowards(rb.rotation, targetRotation, flickSpeed * Time.deltaTime * 100);
         rb.MoveRotation(newRotation);
         yield return null;
      }

      // Rotate back to the initial angle
      while (Mathf.Abs(rb.rotation - initialRotation) > 0.1f)
      {
         float newRotation = Mathf.MoveTowards(rb.rotation, initialRotation, flickSpeed * Time.deltaTime * 100);
         rb.MoveRotation(newRotation);
         yield return null;
      }

      isFlicking = false;
   }
}
