using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvercrowdHuman : MonoBehaviour
{
    Rigidbody rb;


    float basePushSpeed = 1000;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;

            Debug.Log("hii");
        if (other.CompareTag("Human"))
        {
            rb.AddForce((transform.position - other.transform.position).normalized * basePushSpeed, ForceMode.Impulse);
        }
    }
}
