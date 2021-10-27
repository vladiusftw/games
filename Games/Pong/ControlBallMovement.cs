using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlBallMovement : MonoBehaviour
{
    public BallMove ballMove;
    public Text Player1Score;
    public Text Player2Score;
    public int ScoreToWin = 5;   
    private string Winner;
   
    
    

    private void ballPlayerCollide(Collision2D collision)
    {
        Vector2 ballPos = transform.position;
        Vector2 playerPos = collision.gameObject.transform.position;

        float PlayerHeight = collision.collider.bounds.size.y;

        float x;
        if (collision.gameObject.name.Equals("Player1"))
        {
            x = 1;
        }
        else 
        {
            x = -1;
        }

        
        float y = (ballPos.y - playerPos.y) / PlayerHeight;
        ballMove.IncreaseHitCounter();
        ballMove.MoveBall(new Vector2 (x, y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.name=="Player1" || collision.gameObject.name == "Player2")
        {
            ballPlayerCollide(collision);
        }
        else if(collision.gameObject.name== "LeftPlatformWall")
        {
            string getScore2 = Player2Score.text;
            int player2Score = Convert.ToInt32(getScore2);
            player2Score++;
            if (player2Score >= ScoreToWin)
            {
                Winner = "Player 2 Wins!";
                PlayerPrefs.SetString("Winner", Winner);
                PlayerPrefs.Save();
                SceneManager.LoadScene("GameOver");

            }
            
            
                getScore2 = player2Score.ToString();
                Player2Score.text = getScore2;
                ballMove.ResetPos(collision);
                
           
        }
        else if (collision.gameObject.name == "RightPlatformWall")
        {
            string getScore1 = Player1Score.text;
            int player1Score = Convert.ToInt32(getScore1);
            player1Score++;
            if (player1Score >= ScoreToWin)
            {
                Winner = "Player 1 Wins!";
                PlayerPrefs.SetString("Winner", Winner);
                PlayerPrefs.Save();
                SceneManager.LoadScene("GameOver");

            }
            
            
                getScore1 = player1Score.ToString();
                Player1Score.text = getScore1;
                ballMove.ResetPos(collision);
            
            
        }

        

        
    }

    
   
   

}
