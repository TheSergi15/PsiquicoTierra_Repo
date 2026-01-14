using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance; //Definición de la fortaleza de datos 

    public static AudioManager Instance
    {
        //Declaración del Singleton
        get
        {
            if (instance == null) Debug.Log("no hay game Manager");
            return instance;
        }

    }
    //Fin del Singleton 

    //TODAS LAS VARIABLES DE LA FORTALEZA DEBEN SER PÚBLICAS
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip[] musicLibrary;
    public AudioClip[] sfxLibrary;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(int musicPlay)
    {
        musicSource.clip = musicLibrary[musicPlay];
        musicSource.Play();
    }

    public void PauseMusic(int musicPlay)
    {
       musicSource.Pause();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void ResumeMusic()
    {
        musicSource.UnPause();
    }
    public void PlaySFX(int sfxToPlay)
    {
        sfxSource.PlayOneShot(sfxLibrary[sfxToPlay]);
    }
}


