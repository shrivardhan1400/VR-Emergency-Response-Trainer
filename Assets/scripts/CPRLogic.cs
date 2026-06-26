using UnityEngine;

public class CPRLogic : MonoBehaviour
{
    [Header("References")]
    public UIManager uiManager;
    public AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip pressSound;
    public AudioClip successSound;

    [Header("CPR Settings")]
    public float sessionTime = 120f;
    public float targetMinBPM = 100f;
    public float targetMaxBPM = 120f;

    private float timer;
    private int pressCount;
    private float bpm;
    private bool sessionRunning = true;

    void Start()
    {
        timer = sessionTime;
        pressCount = 0;

        if (uiManager != null)
        {
            uiManager.UpdatePressCount(0);
            uiManager.UpdateTimer(timer);
            uiManager.UpdateBPM(0);
            uiManager.ShowStatus("Start CPR", Color.green);
        }
    }

    void Update()
    {
        if (!sessionRunning)
            return;

        timer -= Time.deltaTime;

        if (timer < 0)
            timer = 0;

        if (uiManager != null)
            uiManager.UpdateTimer(timer);

        float elapsed = sessionTime - timer;

        if (elapsed > 0)
        {
            bpm = (pressCount / elapsed) * 60f;

            if (uiManager != null)
                uiManager.UpdateBPM(bpm);
        }

        if (timer <= 0)
        {
            EndSession();
        }
    }

    public void RegisterPress()
    {
        if (!sessionRunning)
            return;

        pressCount++;

        if (uiManager != null)
            uiManager.UpdatePressCount(pressCount);

        if (audioSource != null && pressSound != null)
            audioSource.PlayOneShot(pressSound);

        if (bpm < targetMinBPM)
        {
            uiManager.ShowStatus("Too Slow", Color.red);
        }
        else if (bpm > targetMaxBPM)
        {
            uiManager.ShowStatus("Too Fast", Color.yellow);
        }
        else
        {
            uiManager.ShowStatus("Good Compression", Color.green);
        }
    }

    void EndSession()
    {
        sessionRunning = false;

        if (audioSource != null && successSound != null)
            audioSource.PlayOneShot(successSound);

        if (bpm >= targetMinBPM && bpm <= targetMaxBPM)
        {
            uiManager.ShowStatus("CPR Successful", Color.green);
        }
        else
        {
            uiManager.ShowStatus("Practice Again", Color.red);
        }
    }

    public void RestartTraining()
    {
        timer = sessionTime;
        pressCount = 0;
        bpm = 0;
        sessionRunning = true;

        uiManager.UpdatePressCount(0);
        uiManager.UpdateTimer(timer);
        uiManager.UpdateBPM(0);
        uiManager.ShowStatus("Restarted", Color.white);
    }

    public int GetPressCount()
    {
        return pressCount;
    }

    public float GetCurrentBPM()
    {
        return bpm;
    }

    public float GetRemainingTime()
    {
        return timer;
    }
}