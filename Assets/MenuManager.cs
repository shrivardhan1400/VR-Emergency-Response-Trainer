using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject settingsPanel;

    public void ResumeGame()
    {
        menuPanel.SetActive(false);
    }

    public void RestartScenario()
    {
        Debug.Log("Restart Scenario");
    }

    public void OpenSettings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}