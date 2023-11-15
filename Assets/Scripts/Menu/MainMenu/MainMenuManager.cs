using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenuPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject mapChoicePanel;

    public void ActiveMapChoicePanel()
    {
        mapChoicePanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        MainMenuPanel.SetActive(true);
        mapChoicePanel.SetActive(false);
    }

    public void ActiveSettingsPanel()
    {
        settingsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void DesactiveSettingsPanel()
    {
        MainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void ActiveCreditsPanel()
    {
        creditsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void DesactiveCreditsPanel()
    {
        MainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
