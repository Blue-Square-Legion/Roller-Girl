using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer myAudioMixer;
    [SerializeField] private string Volume = "MasterVol";

    public void SetVolume(float slidervalue) 
    {
        myAudioMixer.SetFloat(Volume, Mathf.Log10(slidervalue) * 20);
    }
}
