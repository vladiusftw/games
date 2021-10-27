using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoosePlayer : MonoBehaviour
{
    public Button button1;
    public Button button2;
    Button.ButtonClickedEvent onClick;
    private void Start()
    {
        button1 = button1.GetComponent<Button>();
        button2 = button2.GetComponent<Button>();
        button1.onClick.AddListener(Player1);
        button2.onClick.AddListener(Player2);
        if(!DontDestroy.AS.isPlaying)
        {
            DontDestroy.AS.Play();
            DontDestroy.AS.loop = true;

        }
    }

    void Player1()
    {
        PlayerPrefs.SetString("Player", "Player1");
        print("Player1");
    }

    void Player2()
    {
        PlayerPrefs.SetString("Player","Player2");
        print("Player2");
    }




}
