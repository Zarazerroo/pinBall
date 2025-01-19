using UnityEngine;

public class SadClownSfx : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
   {
      audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
   }

   private void OnTriggerEnter2D(Collider2D other)
    {
        audioManager.PlaySFX(audioManager.HoneySfx);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
