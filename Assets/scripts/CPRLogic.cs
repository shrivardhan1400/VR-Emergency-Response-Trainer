using UnityEngine;

public class CPRLogic : MonoBehaviour
{
    public UIManager uiManager;

    public AudioSource audioSource;
    public AudioClip idleSound;
    public AudioClip pressSound;
    public AudioClip successSound;

    public int pressCount = 0;

    private float startTime;
    private float duration = 10f;
    private bool isRunning = false;

    void Start()
    {
        startTime = Time.time;
        isRunning = true;

        if (idleSound != null && audioSource != null)
        {
            audioSource.clip = idleSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void RegisterPress()
    {
        if (!isRunning) return;

        pressCount++;

        if (uiManager != null)
            uiManager.UpdateCount(pressCount);

        if (pressSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pressSound);
        }
    }

    void Update()
    {
        if (!isRunning) return;

        float timePassed = Time.time - startTime;

        if (timePassed >= duration)
        {
            float rate = (pressCount / duration) * 60f;

            if (uiManager != null)
            {
                if (rate < 100)
                {
                    uiManager.ShowFeedback("Too Slow", Color.red, 2f, true);
                }
                else if (rate > 120)
                {
                    uiManager.ShowFeedback("Too Fast", Color.red, 2f, true);
                }
                else
                {
                    uiManager.ShowFeedback("Good CPR", Color.green, 3f, false);

                    if (successSound != null && audioSource != null)
                    {
                        audioSource.Stop();
                        audioSource.clip = successSound;
                        audioSource.loop = false;
                        audioSource.Play();
                    }
                }
            }

            isRunning = false;
        }
    }
}