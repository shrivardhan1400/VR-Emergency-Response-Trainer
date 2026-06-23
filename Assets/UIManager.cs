using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI compressionText;

    int compressionCount = 0;

    public void AddCompression()
    {
        compressionCount++;

        compressionText.text =
            "COMPRESSIONS : " + compressionCount;
    }
}