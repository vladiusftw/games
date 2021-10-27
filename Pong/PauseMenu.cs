using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !settingsMenuUI.activeInHierarchy)
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenuUI.activeInHierarchy)
        {
            Pause();
        }
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        DontDestroy.AS.Play();
        Time.timeScale = 1f;
        isGamePaused = false;        
    }

    public void Pause()
    {
       pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        DontDestroy.AS.Pause();
        Time.timeScale = 0f;
        isGamePaused = true;
        
    }

    public void Settings()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    public void ResetGame()
    {            
        SceneManager.LoadScene("ChoosePlayers");
        DontDestroy.AS.Play();
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
