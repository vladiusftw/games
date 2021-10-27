using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    public float speed = 18;
    Rigidbody2D mrb;
    // Start is called before the first frame update
    void Start()
    {
        mrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        mrb.velocity = new Vector2(0, yInput) * speed;
    }
}
