using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static float musicVolue = 1.0f;
    public static float musicEffect = 1.0f;

    public Slider slider_music = null;
    public Slider slider_effects = null;

    public AudioSource MusicAudio = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void changeVolueMusic()
    {
        musicVolue = slider_music.value;
        MusicAudio.volume = musicVolue;
    }
    public void changeVolueEffects()
    {
        musicEffect = slider_effects.value;

    }
}
