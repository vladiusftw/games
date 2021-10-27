using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
