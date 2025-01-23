// Copyright 2025 Muhammad Alhasan. All rights reserved.

using NUnit.Framework;
using System.Collections;
using UnityEngine;
public class TP : MonoBehaviour
{

	public Vector2 TP_end = new Vector2();
	GameObject[] list;

	void Start()
	{
		list = GameObject.FindGameObjectsWithTag("Light");
	}

   void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Ball"))
      {
         // Stop the ball's movement and teleport it
         other.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
         other.transform.position = TP_end;

         // Turn off all lights
         foreach (GameObject light in list)
         {
            light.SetActive(false);
         }

         // Start the coroutine to turn lights back on
         StartCoroutine(WaitAndTurnLightsOn());
      }
   }

   IEnumerator WaitAndTurnLightsOn()
   {
      yield return new WaitForSeconds(2); // Wait for 2 seconds

      // Turn all lights back on
      foreach (GameObject light in list)
      {
         light.SetActive(true);
      }
   }
}
