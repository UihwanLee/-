using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    private AudioSource audiosource;
    private static float musicVolume = 0.5f;

    public static Slider slider;
    public static Toggle toggle;
    public static bool toggledown = true;

	// Use this for initialization
	void Start () {
        audiosource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        audiosource.volume = musicVolume;
    }

    public void musicCheck()
    {
        toggle = (Toggle)FindObjectOfType<Toggle>();
        toggledown = false;
        audiosource.mute = !audiosource.mute;
    }

    public void setVolume(float vol)
    {
        musicVolume = vol;
    }

    public float getValue()
    {
        return musicVolume;
    }

    public Toggle getToggle()
    {
        return toggle;
    }

    public bool getToggledown()
    {
        return toggledown;
    }
}
