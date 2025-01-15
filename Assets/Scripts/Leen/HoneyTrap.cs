using UnityEngine;

public class HoneyTrap : MonoBehaviour
{
    AudioManager audioManager;
    public float speedReductionFactor = 0.5f; // Factor to reduce the speed by (e.g., 0.5 means 50% reduction)

    private void Awake()
   {
      audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object entering the trap is the ball
        Ball ball = collision.GetComponent<Ball>();
        if (ball != null)
        {
            // Get the Rigidbody2D of the ball
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Reduce the velocity by the specified factor
                rb.linearVelocity *= speedReductionFactor;
            }
        }
        audioManager.PlaySFX(audioManager.honey);
    }

}
