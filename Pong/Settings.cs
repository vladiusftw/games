using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public AudioMixer AudioMixer;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    private void Start()
    {
        int QualityIndex = QualitySettings.GetQualityLevel();
        qualityDropdown.value = QualityIndex;
        qualityDropdown.RefreshShownValue();
        int currentResIndex = 0;
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        print(Screen.currentResolution.refreshRate);
        for (int i = 0; i < resolutions.Length; i++)
        {                      
                string option = resolutions[i].width + " x " + resolutions[i].height + "@" + resolutions[i].refreshRate;
                options.Add(option);            
            
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height==Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void VolumeMixer(float volume)
    {
        AudioMixer.SetFloat("volumeMixer", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetGraphics(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void ChangeResolution(int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }

   
}
