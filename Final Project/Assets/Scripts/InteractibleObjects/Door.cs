using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    Transform hinge;

    [SerializeField]
    float rotationAngle = 80;

    [SerializeField]
    float rotationSpeed = 0.9f;

    [SerializeField] private AudioClip doorOpening;
    [SerializeField] private AudioClip doorClosing;
    [SerializeField] private AudioClip doorLocked;
    
    public bool Locked;

    float baseRotation;
    float targetRotation;
    private AudioSource audioSource;
    private SphereCollider col;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        baseRotation = hinge.rotation.y;
        targetRotation = baseRotation;
        col = transform.parent.GetComponentInChildren<SphereCollider>();
    }

    public void Interact(GameObject interactor)
    {


        if (Locked)
        {
            audioSource.PlayOneShot(doorLocked);
            return;
        }
            
        if (targetRotation == baseRotation)
        {
            audioSource.PlayOneShot(doorOpening);
            targetRotation = baseRotation + rotationAngle;
        }
        else
        {
            audioSource.PlayOneShot(doorClosing);
            targetRotation = baseRotation;
        }
    }

    void FixedUpdate()
    {
        if (col != null)
        {
            transform.parent.GetComponentInChildren<SphereCollider>().gameObject.GetComponent<Renderer>().sharedMaterial.SetInteger("On", Locked ? 0 : 1);
        }
        hinge.rotation = Quaternion.Lerp(hinge.rotation, new Quaternion(0, targetRotation, 0, hinge.rotation.w), rotationSpeed);
    }

    public string getToolTipText()
    {
        return Locked ? "The door is locked" : "Press E/left click to open/close";
    }
}
