using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 cameraOrgPos;
    private Vector3 playerOrgPos;
    private Vector3 offset;    
    void Start()
    {
        playerOrgPos = player.transform.localPosition;
        cameraOrgPos = transform.localPosition;
        offset = playerOrgPos - cameraOrgPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = player.transform.localPosition - offset;
    }
}
