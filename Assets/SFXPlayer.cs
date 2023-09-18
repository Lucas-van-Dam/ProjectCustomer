using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private float minInterval;
    [SerializeField] private float maxInterval;
    [SerializeField] private bool waitTillLastCompleted = false;

    private float interval;
    private float timeSinceLastPlay;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        interval = Random.Range(minInterval, maxInterval);
    }

    private void Update()
    {
        if (timeSinceLastPlay > interval)
        {
            if(waitTillLastCompleted && audioSource.isPlaying)
                return;
            audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length - 1)]);
            interval = Random.Range(minInterval, maxInterval);
            timeSinceLastPlay = 0;
        }
        else
        {
            timeSinceLastPlay += Time.deltaTime;
        }
    }
}
