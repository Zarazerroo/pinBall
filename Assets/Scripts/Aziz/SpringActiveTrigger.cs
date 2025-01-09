using System;
using Unity.VisualScripting;
using UnityEngine;

public class SpringActiveTrigger : MonoBehaviour
{
   bool Exit = false;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Ball"))
      {
         other.GetComponent<Ball>().springActive = true;
         Exit = false;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if(!Exit)
      {
         other.GetComponent<Ball>().springActive = false;
         Exit = true;
      }
   }
}
