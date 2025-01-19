// Copyright Abdulaziz Alonizi 2025


using System.Collections;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;
using Math = System.Math;

public class Spring : MonoBehaviour
{
    AudioManager audioManager;
    private Vector3 originalScale;
    private Vector3 originalPosition;
    private float shrinkAmount;
    private float springRate; 

    private void Awake()
   {
      audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
   }
     
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
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioManager.PlaySFX(audioManager.spring);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (originalScale.y * 0.45f < transform.localScale.y)
                transform.ScaleYUpperEdge(-springRate*shrinkAmount);
            audioManager.PlaySFX(audioManager.spring);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.localPosition = originalPosition;
            transform.localScale = originalScale;
            audioManager.PlaySFX(audioManager.spring);
        }
    }


}