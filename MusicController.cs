using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static bool mcExists;
    public AudioSource[] musicTracks;
    public int currentTrack;
    public bool musicCanPlay;

    // Use this for initialization
    void Start()
    {//удаление дупликата музыки при переходе на следующую карту
        if (!mcExists)
        {
            mcExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {//если маркер музыки отмечен, то выбирается текущий звук
        if (musicCanPlay)
        {
            if (musicTracks[currentTrack].isPlaying)
            {
                musicTracks[currentTrack].Play();
            }
        }
        else
        {
            musicTracks[currentTrack].Stop();
        }
     
    }
    //смена звука при переходе
    public void SwitchTrack(int newTrack)
    {
        musicTracks[currentTrack].Stop();
        currentTrack = newTrack;
        musicTracks[currentTrack].Play();
    }
}
