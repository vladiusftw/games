using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   
    public AudioSource wall;
    public AudioSource ball;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Player1" || collision.gameObject.name == "Player2")
        {
            ball.Play();
        }
        else  
        {
            wall.Play();
        }
        
    }

    
}
