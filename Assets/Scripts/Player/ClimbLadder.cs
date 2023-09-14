using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    CharacterController cc;
    Movement movement;

    [SerializeField]
    float climbSpeed = 3;


    private void Start()
    {
        movement = GetComponent<Movement>();
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        foreach (Collider coll in Physics.OverlapSphere(transform.position, transform.localScale.x * 1.05f))
        {
            if (coll.GetComponent<Ladder>() != null && coll.GetComponent<Rigidbody>().useGravity == true && Input.GetKey(KeyCode.W))
            {
                movement.isGrav = false;
                cc.Move(Vector3.up * climbSpeed * Time.deltaTime);
            }
            else
            {
                movement.isGrav = true;
            }
        }
    }
}
