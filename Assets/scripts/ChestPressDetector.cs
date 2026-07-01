using UnityEngine;

public class ChestPressDetector : MonoBehaviour
{
    [Header("Reference")]
    public CPRManager cprManager;

    private float lastPressTime;

    private void Awake()
    {
        if (cprManager == null)
            cprManager = FindFirstObjectByType<CPRManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Hand"))
            return;

        if (Time.time - lastPressTime < 0.2f)
            return;

        lastPressTime = Time.time;

        if (cprManager != null)
            cprManager.RegisterCompression();
    }
}