using UnityEngine;
using UnityEngine.Audio;
public class AudioManagerController : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource walkingSource;
    [SerializeField] AudioSource SFXUISource;

    [Header("-------- Audio clip --------")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip run;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play(); //toca quando começa 
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlaySFXUI(AudioClip clip)
    {
        SFXUISource.PlayOneShot(clip);
    }

    public void Walk()
    {
        walkingSource.clip = run;
        walkingSource.Play();
    }

    public void StopWalk()
    {
        walkingSource.Stop();
    }
}
