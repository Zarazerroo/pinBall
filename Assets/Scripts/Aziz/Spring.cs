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
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.localPosition;
        originalScale = transform.localScale;
        shrinkAmount = 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s"))
        {
            if (originalScale.y * 0.25 < transform.localScale.y)
            {
                transform.localScale -= new Vector3(0f, shrinkAmount, 0f);
                transform.position -= new Vector3(0f, shrinkAmount/2, 0f);
            }
        }

        if (Input.GetKeyUp("s"))
        {
            transform.localPosition = originalPosition;
            transform.localScale = originalScale;
        }
    }
}