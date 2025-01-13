using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---Audio Source---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    

    [Header("---Audio Clip---")]
    public AudioClip background;
    public AudioClip cuphit;
    public AudioClip pothit;
    public AudioClip spring;
    public AudioClip flippers;
    
    
    

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        musicSource.clip = background;
        musicSource.Play();
    }  

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
