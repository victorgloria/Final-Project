using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class optionsController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider volSlider;
    public Slider sfxSlider;

    void Start(){
        if(PlayerPrefs.GetInt("set first time volume") == 0){
            PlayerPrefs.GetInt("set first time volume",1);
            masterSlider.value = .25f;
            volSlider.value = .25f;
            sfxSlider.value = .25f;
        }
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        volSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void setMasterVolume(){
        setVolume("MasterVolume",masterSlider.value);
    }

    public void setMusicVolume(){
        setVolume("MusicVolume",volSlider.value);
    }
    public void setsfxVolume(){
        setVolume("SFXVolume",sfxSlider.value);
    }

    void setVolume(string name, float value){
        float volume = Mathf.Log10(value) * 20;
        if(value == 0){
            volume = -80;
        }
        audioMixer.SetFloat(name,volume);
        PlayerPrefs.SetFloat(name,value);
    }
}
