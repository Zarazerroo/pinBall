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

    [Header("---New Audio Clip---")]
    public AudioClip spring;
    public AudioClip flippers;
    public AudioClip blueitem;
    public AudioClip purpleitem;
    public AudioClip honey;
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
