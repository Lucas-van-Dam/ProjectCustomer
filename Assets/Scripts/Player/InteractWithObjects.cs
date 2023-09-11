using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractWithObjects : MonoBehaviour
{
    Transform cameraTransform;
    [SerializeField]
    TextMeshProUGUI interactToolTip;


    void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        RaycastHit hit = CastRay(2);

        if (hit.collider == null || !hit.collider.CompareTag("InteractableObject"))
            return;

        IInteractable interactable = hit.collider.GetComponent<IInteractable>();


        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            Interacting(interactable);
        }
    }


        


    void Interacting(IInteractable interactable)
    {


        interactable.Interact(this.gameObject);
    }


    public RaycastHit CastRay(float maxDistance)
    {
        Physics.Raycast(transform.position, cameraTransform.forward, out RaycastHit hit, maxDistance);

        return hit;
    }
}
