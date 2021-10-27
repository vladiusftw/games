using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float ballSpeed = 10f;
    public float maxSpeed = 30f;
    private int hitCounter = 0;
    private Vector3 orgPos;
    Rigidbody2D mrb;
    
    // Start is called before the first frame update
    void Start()
    {
        
        orgPos = transform.position;
        mrb = GetComponent<Rigidbody2D>();
        int startingPlayer = StartingPlayer();
        if (startingPlayer == 1)
        {
            MoveBall(new Vector2(-1, 0));
        }
        else
        {
            MoveBall(new Vector2(1, 0));
        }
    }


    public void MoveBall(Vector2 dir)
    {       
        dir = dir.normalized;
        float speed = ballSpeed + (hitCounter * 2);
        print(speed);
        mrb.velocity = dir * speed;       
    }

    private int StartingPlayer()
    {
        int isStartingPlayer = Random.Range(1, 3);
        return isStartingPlayer;
    }

    public void IncreaseHitCounter()
    {
        if(ballSpeed + (hitCounter * 2) < maxSpeed)
        {
            hitCounter++;
        }
    }

    public void ResetPos(Collision2D collision)
    {
        transform.position = orgPos;
        hitCounter = 0;
        if (collision.gameObject.name == "LeftPlatformWall")
        {
            MoveBall(new Vector2(1, 0));
        }
        else
        {
            MoveBall(new Vector2(-1, 0));
        }
    }
}
