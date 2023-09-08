using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObjects : MonoBehaviour
{
    Transform cameraTransform;



    void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interacting();
        }

    }


    void Interacting()
    {
        RaycastHit hit = CastRay(2);


        if (hit.collider != null && hit.collider.CompareTag("InteractableObject"))
        {
            hit.collider.GetComponent<IInteractable>().Interact(this.gameObject);
        }
    }


    public RaycastHit CastRay(float maxDistance)
    {
        Physics.Raycast(transform.position, cameraTransform.forward, out RaycastHit hit, maxDistance);

        return hit;
    }
}
