using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{

    public Slider audioSlider;

    public void AudioControl()
    {
        float sound = audioSlider.value;

        AudioSource audioSource = AudioManager.instance.GetComponent<AudioSource>(); ;

        audioSource.volume = sound;

      
    }
 
}
