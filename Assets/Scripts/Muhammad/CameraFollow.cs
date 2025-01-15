using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField] private float smoothSpeed = 0.125f; // Speed of smoothing
   [SerializeField] private Vector2 offset; // Offset in X and Y axes
   [SerializeField] private float zOffset = -10f; // Fixed Z position of the camera

   private GameObject ball; // Cached reference to the current ball

   private void LateUpdate()
   {
      // Find the ball with the tag "Ball"
      ball = GameObject.FindWithTag("Ball");

      if (ball != null)
      {
         // Define the target position with offset
         Vector3 targetPosition = new Vector3(ball.transform.position.x + offset.x, ball.transform.position.y + offset.y, zOffset);

         // Smoothly interpolate between the current position and the target position
         transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
      }
      else
      {
         Debug.LogWarning("No object with tag 'Ball' found.");
      }
   }
}
