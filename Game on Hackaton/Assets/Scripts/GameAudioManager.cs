using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public AudioSource MusicAudio = null;
    // Start is called before the first frame update
    void Start()
    {
        MusicAudio.volume = AudioManager.musicVolue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
