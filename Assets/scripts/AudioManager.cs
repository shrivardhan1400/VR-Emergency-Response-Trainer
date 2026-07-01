using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip compressionClip;
    public AudioClip successClip;
    public AudioClip failureClip;

    private void Awake()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayCompressionSound()
    {
        if (compressionClip != null)
            audioSource.PlayOneShot(compressionClip);
    }

    public void PlaySuccessSound()
    {
        if (successClip != null)
            audioSource.PlayOneShot(successClip);
    }

    public void PlayFailureSound()
    {
        if (failureClip != null)
            audioSource.PlayOneShot(failureClip);
    }
}