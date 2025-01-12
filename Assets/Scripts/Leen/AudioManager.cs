using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---Audio Source---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource WalkSource;

    [Header("---Audio Clip---")]
    public AudioClip background;
    public AudioClip cuphit;
    public AudioClip pothit;
    

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        musicSource.clip = background;
        musicSource.Play();
    }  
}
