using UnityEngine;

public class CPRLogic : MonoBehaviour
{
    int pressCount = 0;
    float startTime;
    float duration = 15f;

    public UIManager uiManager;

    bool isRunning = true;

    void Start()
    {
        startTime = Time.time;
    }

    public void RegisterPress()
    {
        if (!isRunning) return;

        pressCount++;

        if (uiManager != null)
        {
            uiManager.UpdateCount(pressCount);
        }
    }

    void Update()
    {
        if (!isRunning) return;

        // TEMP TEST (remove when VR is connected)
        if (Input.GetKeyDown(KeyCode.Space))
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

                    // 🔥 STOP COMPLETELY
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