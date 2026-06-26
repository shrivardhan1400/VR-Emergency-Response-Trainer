using UnityEngine;

public class ChestPressDetector : MonoBehaviour
{
    [Header("References")]
    public CPRLogic cprLogic;

    [Header("Compression Settings")]
    public float compressionCooldown = 0.35f;

    private float lastCompressionTime = -1f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Hand"))
            return;

        if (Time.time - lastCompressionTime < compressionCooldown)
            return;

        lastCompressionTime = Time.time;

        Debug.Log("Chest Compression Detected");

        if (cprLogic != null)
        {
            cprLogic.RegisterPress();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        BoxCollider box = GetComponent<BoxCollider>();

        if (box != null)
        {
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(box.center, box.size);
        }
    }
}