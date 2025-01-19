using UnityEngine;

public class MagneticRepel : MonoBehaviour
{
    AudioManager audioManager;
    public float repelForce = 10f; // Strength of the repelling force

    private void Awake()
   {
      audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
   }

   private void OnTriggerEnter2D(Collider2D other)
    {
        audioManager.PlaySFX(audioManager.MagneticRepelSfx);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the object is the ball
        if (other.CompareTag("Ball"))
        {
            // Get the Rigidbody2D of the ball
            Rigidbody2D ballRigidbody = other.GetComponent<Rigidbody2D>();
            if (ballRigidbody != null)
            {
                // Calculate the direction from the magnetic item to the ball
                Vector2 direction = other.transform.position - transform.position;
                direction.Normalize(); // Ensure the direction vector is of unit length

                // Apply a repelling force to the ball
                ballRigidbody.AddForce(direction * repelForce, ForceMode2D.Force);
            }
        }
    }
}
