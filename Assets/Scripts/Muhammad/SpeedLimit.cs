using UnityEngine;

public class SpeedLimit : MonoBehaviour
{
   public Rigidbody2D rb;
   public float maxVelocity = 10f;

   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
   }

   void FixedUpdate()
   {
      if (rb.linearVelocity.magnitude > maxVelocity)
      {
         rb.linearVelocity = rb.linearVelocity.normalized * maxVelocity;
      }
   }
}
