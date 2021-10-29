using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    Rigidbody rb;
    
    public static bool spawnTile = false;
    private float originalyPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalyPos = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        addTiles();
    }

    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(0.6f);
        rb.isKinematic = false;


    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(FallDown());
    }

    void addTiles()
    {
        if (Mathf.Abs(originalyPos-transform.localPosition.y)>=1.5)
        {
            Destroy(gameObject);
            spawnTile = true;
        }
    }
}
