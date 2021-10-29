using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class changeMaterial : MonoBehaviour
{
    private Material[] mats;
    [SerializeField] Material material1;
    [SerializeField] Material material2;
    [SerializeField] Material material3;
    [SerializeField] Material material4;
    [SerializeField]Renderer rend;
    private float speedBall;
    // Start is called before the first frame update
    void Start()
    {
        
        speedBall = BallMovement.speed;
        mats = new Material[4]{material1,material2,material3,material4}; 

    }

    // Update is called once per frame
    void Update()
    {
        changeMats();
        if (PlayerPrefs.GetString("matsChange")=="true")
        {
            rend.material = mats[PlayerPrefs.GetInt("mats")];
        }
    }

    void changeMats()
    {
        
        if(speedBall!=BallMovement.speed)
        {
            
            System.Random rand = new System.Random();
            int randomNum = rand.Next(0, 4);
            while (rend.material == mats[randomNum])
            {
                randomNum = rand.Next(0, 4);
            }
            rend.material = mats[randomNum];
            PlayerPrefs.SetInt("mats", randomNum);
            PlayerPrefs.SetString("matsChange", "true");
            speedBall = BallMovement.speed;
        }

        
    }
}
