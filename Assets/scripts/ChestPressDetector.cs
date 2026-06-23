using UnityEngine;

public class ChestPressDetector : MonoBehaviour
{
    [SerializeField] private PressLogic logic;

    private float lastPressTime;
    private float cooldown = 0.25f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("VRHand"))
            return;

        if (Time.time - lastPressTime < cooldown)
            return;

        lastPressTime = Time.time;

        Debug.Log("Pressed");

        if (logic != null)
        {
            logic.RegisterPress();
        }
    }
}