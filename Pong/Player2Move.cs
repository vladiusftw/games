using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : MonoBehaviour
{
    public GameObject ball;
    public Collider2D col;
    public float speed = 18f;
    Rigidbody2D mrb;
    private Vector2 RacketPos;
    private float yOrgPos;
    private float ballYpos;
    private float ballXpos;
    void Start()
    {
        
        mrb = GetComponent<Rigidbody2D>(); 
        yOrgPos = transform.localPosition.y;             
        ballYpos = ball.transform.localPosition.y;
        ballXpos = ball.transform.localPosition.x;
    }

    private void FixedUpdate()
    {       
            MovePlayer();              
    }
   




    void MovePlayer()
    {
        if (PlayerPrefs.GetString("Player")=="Player2")
        {
            speed = 18;
            float yInput = Input.GetAxis("Vertical2");
            mrb.velocity = new Vector2(0, yInput) * speed;
        }
        else
        {
            speed = 18 - 5 ;
            float RacketBallDiff = Mathf.Abs(ballYpos - yOrgPos);
            
            if(ball.transform.localPosition.x > ballXpos)
            {

                if (transform.localPosition.y < ball.transform.localPosition.y - RacketBallDiff)
                {
                    mrb.velocity = new Vector2(0, 1) * (speed);
                    mrb.velocity = Vector2.ClampMagnitude(mrb.velocity, speed);
                }
                else
                {
                    mrb.velocity = new Vector2(0, -1) * (speed);
                    mrb.velocity = Vector2.ClampMagnitude(mrb.velocity, speed);
}
            }
            else
            {
                mrb.velocity = new Vector2(0, 0);
            }
            
            
        }
    }

     
}
