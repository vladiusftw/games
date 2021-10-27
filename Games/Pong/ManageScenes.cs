using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    

    public void StartScene()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void ChoosePlayerScene()
    {
        SceneManager.LoadScene("ChoosePlayers");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name=="StartScreen")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("ChoosePlayers");
            }
                



        }
    }

}
