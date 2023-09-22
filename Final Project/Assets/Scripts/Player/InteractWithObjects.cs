using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractWithObjects : MonoBehaviour
{
    Transform cameraTransform;
    [SerializeField]
    Image interactToolTip;
    [SerializeField]
    TextMeshProUGUI toolTipText;

    [SerializeField] private Material outlineMat;

    IInteractable iinteractable = null;


    void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        if (!GetComponent<Movement>().recieveInput)
        {
            return;
        }
        RaycastHit hit = CastRay(2);

        if (hit.collider == null || !hit.collider.CompareTag("InteractableObject"))
        {
            interactToolTip.enabled = false;
            toolTipText.text = "";
            return;
        }

        IInteractable interactable = hit.collider.GetComponent<IInteractable>();

        if (iinteractable != interactable)
        {
            if (hit.collider.GetComponent<Door>() != null && hit.collider.GetComponent<Door>().Locked == true)
            {
                toolTipText.text = interactable.getToolTipText();
            }
            else if (hit.collider.GetComponent<PuzzleLoader>() != null && (hit.collider.GetComponent<PuzzleLoader>().piecesToCollect > 0 || hit.collider.GetComponent<PuzzleLoader>().IsPuzzleComplete()))
            {
                toolTipText.text = interactable.getToolTipText();
            }
            else
            {
                interactToolTip.enabled = true;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            Interacting(interactable);
        }
    }

    void Interacting(IInteractable interactable)
    {

        interactToolTip.enabled = false;
        toolTipText.text = "";


        interactable.Interact(this.gameObject);
    }


    public RaycastHit CastRay(float maxDistance)
    {
        Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, maxDistance);

        return hit;
    }
}
