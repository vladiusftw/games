using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointJump : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 jumpPos;
    private Vector3 orgPos;
    private float t;
    private float speed = 1;
    private bool isGrounded = true;
    private float timer = 0;
    private float timeNeeded = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        orgPos = transform.localPosition; 
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeNeeded)
        {
            jumpBall();
            timer = timer - timer;
        }
        
    }


    void jumpBall()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(0, 0.4f, 0) * speed;
            isGrounded = false;
        }
        else
        {
            if (transform.localPosition.y>orgPos.y+0.05f)
            {
                rb.velocity = new Vector3(0, -0.4f, 0) * speed;
            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
                isGrounded = true;
            }
            
        }
    }

    


}
