// Copyright Abdulaziz Alonizi 2025

using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    
    [SerializeField] private Text time;
    public bool springActive = true; 
    private float counter = 0;
   public int X = 500;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        springActive = true; 
    }

    // Update is called once per frame
    void Update()
    {
        //time.text = counter.ToString(); 
        if(Input.GetKey("s")){
            counter += Time.deltaTime;
        }
        
        if (Input.GetKeyUp("s"))
        {
            if (springActive)
            {
                KickBall();
                counter = 0;
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
