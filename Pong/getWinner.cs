using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class getWinner : MonoBehaviour
{
    public TextMeshProUGUI mytxt;
    void Start()
    {
        mytxt.text = PlayerPrefs.GetString("Winner");
        DontDestroy.AS.Stop();
        
    }

    
    
}
