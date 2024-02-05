using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMusic : MonoBehaviour
{

    public GameObject sound;

    private void Awake()
    {
        sound = GameObject.Find("SoundManager");
    }

    private void Start()
    {
        if (sound is not null)
        {
            sound.GetComponent<SoundManager>().PauseMusic();
        }
    }
    private void OnEnable()
    {
        if(sound is not null)
        {
            sound.GetComponent<SoundManager>().PauseMusic();
        }
    }

    private void OnDisable()
    {              
        if(sound is not null)
        {
            sound.GetComponent<SoundManager>().PlayMusic();
        }
    }

}
