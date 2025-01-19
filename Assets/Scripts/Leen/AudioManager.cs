using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---Audio Source---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    

    [Header("---Audio Clip---")]
    public AudioClip background;
    public AudioClip Points;

    [Header("---New Audio Clip---")]
    public AudioClip spring;
    public AudioClip flippers;
    public AudioClip MagneticRepelSfx;
    public AudioClip RotateSfx;
    public AudioClip HoneySfx;
    public AudioClip boosters;
    public AudioClip shredding;
    

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
