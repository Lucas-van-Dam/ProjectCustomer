using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    GameObject player;
    Transform cameraTransform;
    Rigidbody rb;

    [SerializeField]
    float hoverDistance = 2;
    [SerializeField]
    float hoverSpeed = 20;
    [SerializeField]
    float hoverDrag = 20;
    [SerializeField]
    Vector3 hoverOffset = Vector3.zero;


    bool isBeingHeld = false;

    bool justPutDown = false;


    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetKeyDown(KeyCode.E) && isBeingHeld)
        {
            Drop();
        }
    }

    void FixedUpdate()
    {
        if (isBeingHeld)
        {
            if (Vector3.Distance(transform.position, GetHoverTargetPosition()) > 0.5f)
            {
                Vector3 moveDir = (GetHoverTargetPosition() - transform.position).normalized * hoverSpeed;

                rb.AddForce(moveDir);
            }

            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }
    }

    void LateUpdate()
    {
        justPutDown = false;
    }


    void PickingUp()
    {
        rb.useGravity = false;
        rb.drag = hoverDrag;

        isBeingHeld = true;

        gameObject.layer = 2;

    }

    void Drop()
    {
        rb.useGravity = true;
        rb.drag = 0;
        isBeingHeld = false;
        gameObject.layer = 0;
        justPutDown = true;

    }


    public void Interact(GameObject interactor)
    {
        if (!justPutDown)
        {
            player = interactor;
            cameraTransform = player.GetComponentInChildren<Camera>().transform;
            PickingUp();
        }
    }


    Vector3 GetHoverTargetPosition()
    {
        return player.transform.position + (cameraTransform.forward * hoverDistance) + hoverOffset;
    }

    public string getToolTipText()
    {
        return "Press E/left click to pickup/drop";
    }
}
