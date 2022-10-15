using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingsScreen()
    {
        ShowSettingsPanel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowSettingsPanel()
    {
        settingsPanel.gameObject.SetActive(true);
    }
    public void HideSettingsPanel()
    {
        settingsPanel.gameObject.SetActive(false);
    }
}
