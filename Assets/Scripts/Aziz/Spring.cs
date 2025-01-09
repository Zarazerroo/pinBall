// Copyright Abdulaziz Alonizi 2025


using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;
using Math = System.Math;

public class Spring : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 originalPosition;
    private float shrinkAmount;
    private float springRate; 
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.localPosition;
        originalScale = transform.localScale;
        shrinkAmount = 0.01f;
        springRate = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (originalScale.y * 0.25 < transform.localScale.y)
            {
                transform.ScaleYUpperEdge(-springRate*shrinkAmount);
                // transform.localScale -= new Vector3(0f, springRate*shrinkAmount*Time.deltaTime, 0f);
                // transform.position -= new Vector3(0f, springRate*(shrinkAmount/2)*Time.deltaTime, 0f);
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.localPosition = originalPosition;
            transform.localScale = originalScale;
        }
    }
}