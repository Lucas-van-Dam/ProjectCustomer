using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    GameObject player;
    Transform cameraTransform;

    [SerializeField]
    float hoverDistance = 5;


    bool isBeingHeld = false;

    bool justPutDown = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraTransform = player.GetComponentInChildren<Camera>().transform;
    }


    void Update()
    {
        if (isBeingHeld)
        {
            transform.position = Vector3.Lerp(transform.position, GetHoverTargetPosition(), 0.1f);
                
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(cameraTransform.position - transform.position, Vector3.up), 1);


            if (Input.GetMouseButtonDown(0))
            {
                isBeingHeld = false;
                gameObject.layer = 0;
                justPutDown = true;
            }
        }
    }

    void LateUpdate()
    {
        justPutDown = false;
    }


    public void Interact(GameObject interactor)
    {
        if (!justPutDown)
        {
            isBeingHeld = true;

            gameObject.layer = 2;
        }
    }


    Vector3 GetHoverTargetPosition()
    {
        RaycastHit hit = player.GetComponent<InteractWithObjects>().CastRay(6.5f);

        if (hit.collider != null)
        {
            return hit.point + hit.normal * transform.lossyScale.y / 2;
        }

        return player.transform.position + (cameraTransform.forward * hoverDistance);
    }
}
