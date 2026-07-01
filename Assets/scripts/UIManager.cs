using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Text References")]
    public TMP_Text countText;
    public TMP_Text bpmText;
    public TMP_Text timerText;
    public TMP_Text feedbackText;

    private void Start()
    {
        UpdatePressCount(0);
        UpdateBPM(0);
        UpdateTimer(0);
        ShowStatus("Waiting...", Color.white);
    }

    public void UpdatePressCount(int count)
    {
        if (countText != null)
            countText.text = "Press Count: " + count;
    }

    public void UpdateBPM(float bpm)
    {
        if (bpmText != null)
            bpmText.text = "BPM: " + Mathf.RoundToInt(bpm);
    }

    public void UpdateTimer(float time)
    {
        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(time);
    }

    public void ShowStatus(string message)
    {
        ShowStatus(message, Color.white);
    }

    public void ShowStatus(string message, Color color)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.color = color;
        }
    }
}