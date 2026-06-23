using UnityEngine;

public class CPRLogic : MonoBehaviour
{
    int pressCount = 0;
    float startTime;
    float duration = 15f;

    public UIManager uiManager;

    bool isRunning = true;

    // 🎧 AUDIO
    public AudioSource audioSource;
    public AudioClip idleSound;
    public AudioClip pressSound;
    public AudioClip successSound;

    void Start()
    {
        startTime = Time.time;

        // 🔇 Start idle sound
        if (idleSound != null)
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

        // 🔊 Play press sound
        if (pressSound != null)
        {
            audioSource.PlayOneShot(pressSound);
        }

        if (uiManager != null)
        {
            uiManager.UpdateCount(pressCount);
        }
    }

    void Update()
    {
        if (!isRunning) return;

        // 👉 Use mouse or space (your choice)
        if (Input.GetMouseButtonDown(0))
        {
            RegisterPress();
        }

        float timePassed = Time.time - startTime;

        if (timePassed >= duration)
        {
            float rate = (pressCount / duration) * 60f;

            if (uiManager != null)
            {
                if (rate < 100)
                {
                    uiManager.ShowFeedback("Too Slow", Color.red, 2f, true);
                    ResetSystem();
                }
                else if (rate > 120)
                {
                    uiManager.ShowFeedback("Too Fast", Color.red, 2f, true);
                    ResetSystem();
                }
                else
                {
                    uiManager.ShowFeedback("Good CPR", Color.green, 3f, false);

                    // ❤️ SUCCESS SOUND
                    if (successSound != null)
                    {
                        audioSource.Stop();
                        audioSource.clip = successSound;
                        audioSource.loop = true;
                        audioSource.Play();
                    }

                    isRunning = false;
                }
            }
        }
    }

    void ResetSystem()
    {
        pressCount = 0;
        startTime = Time.time;
    }
}