// Copyright Abdulaziz Alonizi 2025

using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{   
    public float kickStrength = 2f;
    private SpringActiveTrigger springActiveTrigger;
    private Rigidbody2D ballRigidBody;
    private float counter = 0;
    private bool ballOnGround = false;
    private BoxCollider2D boxCollider; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        ballRigidBody = gameObject.GetComponent<Rigidbody2D>();
        springActiveTrigger = FindAnyObjectByType<SpringActiveTrigger>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow)){
            counter += Time.deltaTime;
        }    
        
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (ballOnGround)
            {
                KickBall();
                //springActiveTrigger.isActive = false; 
            }
            counter = 0;

        }
    }

    private void KickBall()
    {
        if (ballRigidBody.totalForce.magnitude <= 0f)
        {
            counter = math.min(2.2f, counter);
            Vector2 appliedForce = new Vector2(0f, counter*kickStrength);
            ballRigidBody.AddForce(appliedForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spring")
        {
            ballOnGround = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spring")
        {
            ballOnGround = false; 
        }    
    }
}
