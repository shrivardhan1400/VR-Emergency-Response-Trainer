using UnityEngine;

public class PressLogic : MonoBehaviour
{
    public int count = 0;

    public void RegisterPress()
    {
        count++;
        Debug.Log("Chest Press Count: " + count);
    }
}