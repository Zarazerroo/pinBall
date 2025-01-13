// Copyright Abdulaziz Alonizi 2025


using System.Collections;
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
        springRate = 150f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (originalScale.y * 0.4f < transform.localScale.y)
                transform.ScaleYUpperEdge(-springRate*shrinkAmount);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.localPosition = originalPosition;
            transform.localScale = originalScale;
        }
    }


}