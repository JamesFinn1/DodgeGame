using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;

    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private Text resolutionText;
    [SerializeField] private Toggle fullscreenToggle;

    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0) { selectedResolution = 0; }

        UpdateResText();
    }

    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Count - 1) { selectedResolution = resolutions.Count - 1; }

        UpdateResText();
    }

    public void ApplySettings()
    {
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].verticle, true);


        if (fullscreenToggle.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }

        mainMenu.HideSettingsPanel();
    }

    public void UpdateResText()
    {
        resolutionText.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].verticle.ToString();
    }

}

[System.Serializable]
public class ResItem
{
    public int horizontal, verticle;

}