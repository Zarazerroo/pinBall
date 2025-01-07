using System;
using Unity.VisualScripting;
using UnityEngine;

public class SpringActiveTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


   private void OnTriggerEnter2D(Collider2D other)
   {
      other.GetComponent<Ball>().springActive = true;


   }

   private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Ball>().springActive = false; 

    }
}
