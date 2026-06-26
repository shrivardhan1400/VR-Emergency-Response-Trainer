using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI pressCountText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bpmText;
    public TextMeshProUGUI statusText;

    private Coroutine statusRoutine;

    private void Start()
    {
        UpdatePressCount(0);
        UpdateTimer(120f);
        UpdateBPM(0);
        statusText.text = "Waiting...";
        statusText.color = Color.white;
    }

    public void UpdatePressCount(int count)
    {
        if (pressCountText != null)
            pressCountText.text = "Press Count : " + count;
    }

    public void UpdateTimer(float seconds)
    {
        if (timerText == null) return;

        int min = Mathf.FloorToInt(seconds / 60);
        int sec = Mathf.FloorToInt(seconds % 60);

        timerText.text = $"Time : {min:00}:{sec:00}";
    }

    public void UpdateBPM(float bpm)
    {
        if (bpmText != null)
            bpmText.text = "CPR Rate : " + Mathf.RoundToInt(bpm) + " BPM";
    }

    public void ShowStatus(string message, Color color)
    {
        if (statusRoutine != null)
            StopCoroutine(statusRoutine);

        statusRoutine = StartCoroutine(StatusRoutine(message, color));
    }

    IEnumerator StatusRoutine(string message, Color color)
    {
        statusText.text = message;
        statusText.color = color;

        yield return new WaitForSeconds(2f);

        statusText.text = "Waiting...";
        statusText.color = Color.white;
    }
}