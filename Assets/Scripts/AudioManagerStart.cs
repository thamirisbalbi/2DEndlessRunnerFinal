using UnityEngine;

public class AudioManagerStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    [Header("-------- Audio clip --------")]
    public AudioClip background;

    // Update is called once per frame
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play(); //toca quando começa 
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
