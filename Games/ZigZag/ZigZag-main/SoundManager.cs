using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource retro;
    [SerializeField] AudioSource point;
    [SerializeField] AudioMixer mixer;
    [SerializeField] Image musicImg;
    [SerializeField] Image soundImg;
    [SerializeField] Sprite On;
    [SerializeField] Sprite Off;
    [SerializeField] Slider volume;
    
    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat("mixer", -40);
       
        retro.Play();
        retro.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        retroSound();
        pointSound();
        
    }

    void retroSound()
    {
        if (Time.timeScale == 0f)
        {
            retro.Pause();
        }
        else
        {
            retro.UnPause();
        }
    }

    void pointSound()
    {
        if (ScoringSystem.touchPlayer)
        {
            point.Play();
        }
    }

    public void changeVolume(float num)
    {
        mixer.SetFloat("mixer",num);
        
        
    }

    public void muteMusic()
    {
        if (!retro.mute)
        {
            retro.mute = true;
            musicImg.sprite = Off;
        }
        else
        {
            retro.mute = false;
            musicImg.sprite = On;
        }
    }

    public void muteSound()
    {
        if (!point.mute)
        {
            point.mute = true;
            soundImg.sprite = Off;
        }
        else
        {
            point.mute = false;
            soundImg.sprite = On;
        }
    }

    
}
