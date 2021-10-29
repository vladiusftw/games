using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    GameObject child;
    private int score;
    public static bool touchPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(2).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("score"));
            PlayerPrefs.Save();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            touchPlayer = true;
            score = PlayerPrefs.GetInt("score");
            child.SetActive(false);
            score++;
            if (score % 50 == 0)
            {
                BallMovement.speed += 0.1f;
                print(BallMovement.speed);
            }
            PlayerPrefs.SetInt("score", score);
            
        }
        
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("score", 0);
        
    }

    private void OnCollisionExit(Collision collision)
    {
        touchPlayer = false;
    }

}
