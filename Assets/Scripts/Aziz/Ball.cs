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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRigidBody = gameObject.GetComponent<Rigidbody2D>();
        springActiveTrigger = FindAnyObjectByType<SpringActiveTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow)){
            counter += Time.deltaTime;
        }
        
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (springActiveTrigger.isActive)
            { 
                KickBall();
                counter = 0;
                springActiveTrigger.isActive = false; 
            }
        }
    }

    private void KickBall()
    {
        if (ballRigidBody.totalForce.magnitude <= 0f)
        {
            counter = math.min(1.8f, counter);
            Vector2 appliedForce = new Vector2(0f, counter*kickStrength);
            ballRigidBody.AddForce(appliedForce, ForceMode2D.Impulse);
        }
    }
    
    
}
