using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Aziz;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Spotlight : MonoBehaviour
{
    [SerializeField] private bool LightSwitch = false; 
    private List<Light2D> AllLights;

    private Color InitialLightColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AllLights = GetComponentsInChildren<Light2D>().ToList();
        InitialLightColor = AllLights[0].color;
    }

    public void WarningFlash(Color color)
    {
        foreach (var light in AllLights)
        { 
            StartCoroutine(light.LightStrobing(strobingFrequency:0.2f,strobingDuration:5,color:color));
        }
    }
    // public void StrobeLights()
    // {
    //     foreach (var light in AllLights)
    //     {
    //         StartCoroutine(light.LightStrobing());
    //     }
    // }
    //
    // public void ChangeColor(Color color)
    // {
    //     foreach (var light in AllLights)
    //     {
    //         light.color = color;
    //     }
    // }
}
