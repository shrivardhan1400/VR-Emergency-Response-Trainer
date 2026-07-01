using UnityEngine;

public class CPRManager : MonoBehaviour
{
    [Header("Session Settings")]
    public float sessionDuration = 120f;
    public float minBPM = 100f;
    public float maxBPM = 120f;

    [Header("Managers")]
    public UIManager uiManager;
    public AudioManager audioManager;
    public ScoreManager scoreManager;

    private int compressionCount = 0;
    private float timer;
    private float bpm = 0f;
    private bool sessionRunning = false;

    public int CompressionCount => compressionCount;
    public float BPM => bpm;
    public float RemainingTime => timer;
    public bool IsRunning => sessionRunning;

    private void Start()
    {
        StartSession();
    }

    private void Update()
    {
        if (!sessionRunning)
            return;

        timer -= Time.deltaTime;

        if (timer < 0)
            timer = 0;

        float elapsed = sessionDuration - timer;

        if (elapsed > 0)
            bpm = (compressionCount / elapsed) * 60f;

        if (uiManager != null)
        {
            uiManager.UpdateTimer(timer);
            uiManager.UpdatePressCount(compressionCount);
            uiManager.UpdateBPM(bpm);
        }

        if (timer <= 0)
            EndSession();
    }

    public void RegisterCompression()
    {
        if (!sessionRunning)
            return;

        compressionCount++;

        if (audioManager != null)
            audioManager.PlayCompressionSound();

        if (uiManager != null)
        {
            if (bpm < minBPM)
                uiManager.ShowStatus("Too Slow", Color.red);
            else if (bpm > maxBPM)
                uiManager.ShowStatus("Too Fast", Color.yellow);
            else
                uiManager.ShowStatus("Good Compression", Color.green);
        }
    }

    public void StartSession()
    {
        compressionCount = 0;
        bpm = 0;
        timer = sessionDuration;
        sessionRunning = true;

        if (uiManager != null)
        {
            uiManager.UpdatePressCount(0);
            uiManager.UpdateTimer(timer);
            uiManager.UpdateBPM(0);
            uiManager.ShowStatus("Start CPR", Color.green);
        }
    }

    public void EndSession()
    {
        sessionRunning = false;

        if (audioManager != null)
            audioManager.PlaySuccessSound();

        if (scoreManager != null)
            scoreManager.CalculateScore(compressionCount, bpm);

        if (uiManager != null)
        {
            if (bpm >= minBPM && bpm <= maxBPM)
                uiManager.ShowStatus("CPR Successful", Color.green);
            else
                uiManager.ShowStatus("Practice Again", Color.red);
        }
    }
}