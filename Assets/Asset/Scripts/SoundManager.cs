using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    public AudioClip clearClip;
    public AudioClip bondClip;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClearSound()
    {
        if (clearClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clearClip);
        }
    }

    public void PlayBondSound()
    {
        if (bondClip != null && audioSource != null)
            audioSource.PlayOneShot(bondClip);
    }
}
