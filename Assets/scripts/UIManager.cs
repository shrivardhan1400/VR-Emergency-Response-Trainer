
using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public TextMeshProUGUI feedbackText;

    // Update count text
    public void UpdateCount(int count)
    {
        countText.text = "Press Count: " + count;
    }

    // Show feedback with optional reset
    public void ShowFeedback(string message, Color color, float duration, bool resetAfter = true)
    {
        StopAllCoroutines();
        StartCoroutine(FeedbackRoutine(message, color, duration, resetAfter));
    }

    IEnumerator FeedbackRoutine(string message, Color color, float duration, bool resetAfter)
    {
        feedbackText.text = message;
        feedbackText.color = color;

        yield return new WaitForSeconds(duration);

        if (resetAfter)
        {
            feedbackText.text = "Waiting...";
            feedbackText.color = Color.white;
        }
    }
}
