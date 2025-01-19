using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Points : MonoBehaviour
{
    AudioManager audioManager;
    private float initialIntensity;
    private Light2D lightComponent;
    private ScoreKeeper theScoreKeeper; 
    [SerializeField] int points = 1;

    private void Awake()
   {
      audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
   }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightComponent = GetComponentInChildren<Light2D>();
        theScoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        initialIntensity = lightComponent.intensity;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    { 
        StartCoroutine(StrobingEffect());
        theScoreKeeper.IncreaseScore(points);
        audioManager.PlaySFX(audioManager.Points); 
    }
    
    
    private IEnumerator StrobingEffect()
    {
        for (int i = 0; i < 5; i++)
        {
            lightComponent.intensity = 0; 
            yield return new WaitForSeconds(0.075f);
            lightComponent.intensity = initialIntensity; 
            yield return new WaitForSeconds(0.075f);
        }
    }
    
}
