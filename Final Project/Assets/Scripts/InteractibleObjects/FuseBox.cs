using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FuseBox : MonoBehaviour, IInteractable
{
    [SerializeField] private Door door;
    [SerializeField] private AudioClip sound;

    private bool interacted = false;

    public void Interact(GameObject interactor)
    {
        if (interacted)
        {
            return;
        }
        door.Locked = false;
        interacted = true;
        GetComponent<AudioSource>().PlayOneShot(sound);
        GetComponentInChildren<SphereCollider>().GetComponent<MeshRenderer>().material.SetInt("_On", 1);
    }

    public string getToolTipText()
    {
        return "Press E/left click to unlock door";
    }
}
