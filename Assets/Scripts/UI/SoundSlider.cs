using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SoundSlider : MonoBehaviour
{
    [SerializeField]
    string mixerGroup;

    [SerializeField]
    AudioMixer mixer;



    public void SetSoundEffectVolume(float volume)
    {
        mixer.SetFloat(mixerGroup, volume);
    }
}
