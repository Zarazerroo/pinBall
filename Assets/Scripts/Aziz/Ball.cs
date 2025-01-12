// Copyright Abdulaziz Alonizi 2025

using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private SpringActiveTrigger springActiveTrigger; 
    //public bool springActive = true; 
    private float counter = 0;
    public int X = 300;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        counter = math.min(1.3f, counter);
        //Debug.Log(counter.ToString());
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,counter * X));
    }
    
    
}
