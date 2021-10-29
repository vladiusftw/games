using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageScenes : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject settingsMenuUI;
    public static bool restartGame = false;
    public void Restart()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       

    }

    private void Start()
    {
        PlayerPrefs.SetInt("score", 0);
        
        Time.timeScale = 1f;
        
       
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        gameOver();
        pauseMenu();
    }

    void gameOver()
    {
        if (BallMovement.gameOver)
        {
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
        }
    }

    void pauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
                if (pauseMenuUI.activeInHierarchy)
                {
                    pauseMenuUI.SetActive(false);
                    Time.timeScale = 1f;
                }
                else
                {
                    pauseMenuUI.SetActive(true);
                    Time.timeScale = 0f;

                }
            
            
        }
    }

    public void settings()
    {
        pauseMenuUI.SetActive(true);
    }

    public void playGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void activateSettings()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }



    
}
