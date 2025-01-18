using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.Rendering.Universal;



public class LightStrobe : MonoBehaviour
{
    private Light2D lightComponent;
    private float initialIntensity; 
        

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightComponent = GetComponentInChildren<Light2D>();
        initialIntensity = lightComponent.intensity;
        StartCoroutine(StrobingEffect());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator  StrobingEffect()
    {
        for (int i = 0; i < 5; i++)
        {
            lightComponent.intensity = 0; 
            yield return new WaitForSeconds(0.1f);
            lightComponent.intensity = initialIntensity; 
            yield return new WaitForSeconds(0.1f);
        }
    }
}
