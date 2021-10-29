using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject settingsMenuUI;
    [SerializeField] TMP_Dropdown resDrop;
    [SerializeField] Toggle fullS;
    Resolution[] resolutions;
    List<string> values = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string value = resolutions[i].height + "x" + resolutions[i].width + "@" + resolutions[i].refreshRate;
            values.Add(value);
        }
        resDrop.ClearOptions();
        resDrop.AddOptions(values);
        fullS.isOn = Screen.fullScreen;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && settingsMenuUI.activeInHierarchy)
        {
            resume();
        }
    }

    public void changeResolutions(int value)
    {
        Screen.SetResolution(resolutions[value].width, resolutions[value].height, Screen.fullScreen);

    }

    public void resume()
    {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void fullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}

