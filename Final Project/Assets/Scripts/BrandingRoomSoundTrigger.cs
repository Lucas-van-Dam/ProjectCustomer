using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BrandingRoomSoundTrigger : MonoBehaviour
{
    [SerializeField]
    AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>() != null)
        {
            sound.Play();

            Destroy(gameObject);
        }
    }
}
