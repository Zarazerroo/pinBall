using System;
using Unity.VisualScripting;
using UnityEngine;

public class SpringActiveTrigger : MonoBehaviour
{
   bool Exit = false;
   public Ball ball;

   private void OnTriggerEnter2D(Collider2D other)
   {

      if (other.gameObject.CompareTag("Ball"))
      {
         ball.springActive = true;
         Exit = false;

      }


   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if(!Exit )
      {
         ball.springActive = false;
         Exit = true;
      }


   }
}
