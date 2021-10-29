using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
   
    public static float speed = 4f;
    public static bool gameStarted = false;
    public static bool gameOver = false;
    private bool isLeft;
    Rigidbody rb;
    public GameObject pressStart;
    private bool activateTimer = false;
    private float timer = 0;
    private float waitTime = 1f;

    private void Start()
    {
        gameStarted = false;
        gameOver = false;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressStart.SetActive(false);
            gameStarted = true;
        }
        if (gameStarted)
        {
            MoveBall();
            
            
        }

        if (activateTimer)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                gameOver = true;
            }
        }
        else
        {
            timer = 0;
            
        }

        
        
    }

    void MoveBall()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isLeft = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {            
            isLeft = false;
        }

        if (isLeft)
        {
            rb.transform.rotation = Quaternion.Euler(0, -45, 0);
        }
        else
        {
            rb.transform.rotation = Quaternion.Euler(0, 45, 0);
        }

        rb.transform.localPosition = transform.localPosition + transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        activateTimer = false;
    }

    private void OnCollisionExit(Collision collision)
    {   
        activateTimer = true;
    }


}
