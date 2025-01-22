using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Aziz
{
    public static class Light2DExtension
    { 
        public static IEnumerator LightStrobing(this Light2D light ,float strobingFrequency = 0.1f, int strobingDuration =5  )
        {
            var lightInitialIntensity = light.intensity; 
            for (int i = 0; i < strobingDuration; i++)
            {
                light.intensity = 0;
                yield return new WaitForSeconds(strobingFrequency);
                light.intensity = lightInitialIntensity;
                yield return new WaitForSeconds(strobingFrequency);
            }
        }
        
        public static IEnumerator LightStrobing(this Light2D light, Color color ,float strobingFrequency = 0.1f, int strobingDuration =5  )
        {
            var lightInitialColor = light.color; 
            var lightInitialIntensity = light.intensity; 
            for (int i = 0; i < strobingDuration; i++)
            {
                light.color = color;
                light.intensity = 0;
                yield return new WaitForSeconds(strobingFrequency);
                light.intensity = lightInitialIntensity;
                yield return new WaitForSeconds(strobingFrequency);
                light.color = lightInitialColor;
            }
        }
    }
}