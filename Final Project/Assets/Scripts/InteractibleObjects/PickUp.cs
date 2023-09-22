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

    [SerializeField]
    private AudioClip pickUpObject;
    [SerializeField]
    private AudioClip dropObject; 

    private AudioSource audioSource; 

    bool isBeingHeld = false;

    bool justPutDown = false;

    bool isLadder = false;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
    
        if (GetComponent<Ladder>() != null)
        {
            isLadder = true;
        }
    }


    void Update()
    {
        if ((Input.GetMouseButtonUp(0) || Input.GetKeyDown(KeyCode.E)) && isBeingHeld)
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

            audioSource.PlayOneShot(pickUpObject);


        }
    }


    Vector3 GetHoverTargetPosition()
    {
        Vector3 targetPos = player.transform.position + (cameraTransform.forward * hoverDistance) + hoverOffset;

        /*
        if (isLadder)
        {
            Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit);

            float distanceToGround = Vector3.Distance(transform.position, hit.point);

            if (distanceToGround > transform.lossyScale.y / 2)
            {
                targetPos.y -= distanceToGround - transform.lossyScale.y / 2;
            }
        }
        */

        return targetPos;
    }

    public string getToolTipText()
    {
        return "Press E/left click to pickup/drop";
    }
}
