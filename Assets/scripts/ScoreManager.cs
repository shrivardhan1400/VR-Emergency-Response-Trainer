using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Final Score")]
    public int finalScore = 0;

    public int CalculateScore(int compressions, float avgBPM)
    {
        int score = 0;

        // Compression Score (50)
        score += Mathf.Clamp(compressions, 0, 50);

        // BPM Score (50)
        if (avgBPM >= 100 && avgBPM <= 120)
        {
            score += 50;
        }
        else
        {
            float diff = Mathf.Abs(avgBPM - 110f);
            score += Mathf.Max(0, 50 - Mathf.RoundToInt(diff));
        }

        finalScore = Mathf.Clamp(score, 0, 100);

        return finalScore;
    }
}