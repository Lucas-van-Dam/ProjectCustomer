using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    CharacterController cc;

    [SerializeField]
    float climbSpeed = 3;


    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        foreach (Collider coll in Physics.OverlapSphere(transform.position, transform.localScale.x * 1.5f))
        {
            if (coll.GetComponent<Ladder>() != null && coll.GetComponent<Rigidbody>().useGravity == true)
            {
                cc.Move(Vector3.up * climbSpeed * Time.deltaTime);
            }
        }
    }
}
