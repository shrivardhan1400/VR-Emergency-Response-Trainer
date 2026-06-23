using UnityEngine;

public class ChestPressDetector : MonoBehaviour
{
    public CPRLogic cprLogic;

    private bool isPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && !isPressed)
        {
            isPressed = true;

            Debug.Log("Chest Press Detected");

            if (cprLogic != null)
            {
                cprLogic.RegisterPress();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isPressed = false;
        }
    }
}