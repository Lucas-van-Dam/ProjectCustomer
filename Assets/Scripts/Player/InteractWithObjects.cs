using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractWithObjects : MonoBehaviour
{
    Transform cameraTransform;
    [SerializeField]
    TextMeshProUGUI interactToolTip;

    IInteractable iinteractable = null;


    void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        RaycastHit hit = CastRay(2);

        if (hit.collider == null || !hit.collider.CompareTag("InteractableObject"))
        {
            interactToolTip.text = "";
            return;
        }

        IInteractable interactable = hit.collider.GetComponent<IInteractable>();

        if (iinteractable != interactable)
        {
            interactToolTip.text = "left click/'E' to " + interactable.getToolTipText();
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            Interacting(interactable);
        }
    }





    void Interacting(IInteractable interactable)
    {

        interactToolTip.text = "";

        interactable.Interact(this.gameObject);
    }


    public RaycastHit CastRay(float maxDistance)
    {
        Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, maxDistance);

        return hit;
    }
}
