using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    Transform hinge;

    [SerializeField]
    float rotationAngle = 80;

    [SerializeField]
    float rotationSpeed = 0.9f;

    public bool Locked;

    float baseRotation;
    float targetRotation;


    void Start()
    {
        baseRotation = hinge.rotation.y;
        targetRotation = baseRotation;
    }

    public void Interact(GameObject interactor)
    {
        if (Locked)
            return;
        if (targetRotation == baseRotation)
            targetRotation = baseRotation + rotationAngle;
        else
            targetRotation = baseRotation;
    }

    void FixedUpdate()
    {
        hinge.rotation = Quaternion.Lerp(hinge.rotation, new Quaternion(0, targetRotation, 0, hinge.rotation.w), rotationSpeed);
    }

    public string getToolTipText()
    {
        return Locked ? "The door is locked" : "Press E/left click to open/close";
    }
}
