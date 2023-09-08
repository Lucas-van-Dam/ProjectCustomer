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

    float baseRotation;
    float targetRotation;


    void Start()
    {


        baseRotation = hinge.rotation.y;
        targetRotation = baseRotation;
    }

    public void Interact(GameObject interactor)
    {
        Debug.Log("??????");
        if (targetRotation == baseRotation)
            targetRotation = baseRotation + rotationAngle;
        else
            targetRotation = baseRotation;
    }

    void FixedUpdate()
    {
        hinge.rotation = Quaternion.Lerp(hinge.rotation, new Quaternion(0, targetRotation, 0, 1), rotationSpeed);
        //Debug.Log(hinge.rotation);
        //Debug.Log(new Quaternion(0, targetRotation, 0, 1));
        
    }
}
