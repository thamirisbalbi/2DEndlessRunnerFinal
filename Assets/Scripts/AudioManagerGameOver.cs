using UnityEngine;

public class AudioManagerGameOver : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource SFXUISource;

     [Header("-------- Audio clip --------")]
     public AudioClip death;


     private void Start()
    {
        PlaySFX(death); 
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlaySFXUI(AudioClip clip)
    {
        SFXUISource.PlayOneShot(clip); // para conseguir mudar seu volume no mixer preciso colocar separado 
    }
}
