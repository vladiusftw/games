using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausedGame : MonoBehaviour
{
    [SerializeField] GameObject pressStartUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            pressStartUI.SetActive(false);
        }
        else if(Time.timeScale==1f && !BallMovement.gameStarted)
        {
            pressStartUI.SetActive(true);
        }

        
    }

    
}
