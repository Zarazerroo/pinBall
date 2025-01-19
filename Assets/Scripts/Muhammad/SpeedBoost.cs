using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
   public float speedFactor = 2f; 

   private ParticleSystem vfx;
   private AudioSource[] sources;

   private void Start()
   {
      vfx = GetComponentInChildren<ParticleSystem>();
      sources = GetComponentsInChildren<AudioSource>();
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      vfx.Play();
      foreach (var sfx in sources)
      {
         sfx.Play();
      }
      
      // Check if the object entering the trap is the ball
      Ball ball = collision.GetComponent<Ball>();
      if (ball != null)
      {
         // Get the Rigidbody2D of the ball
         Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
         if (rb != null)
         {
            // Reduce the velocity by the specified factor
            rb.linearVelocity *= speedFactor;
         }
      }
   }

}
