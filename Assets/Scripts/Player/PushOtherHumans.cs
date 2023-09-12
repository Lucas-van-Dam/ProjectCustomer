using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOtherHumans : MonoBehaviour
{
    [SerializeField]
    float pushForce, pushDistance;

    void FixedUpdate()
    {
        foreach (Collider coll in Physics.OverlapSphere(transform.position, transform.localScale.x * pushDistance))
        {
            if (coll.gameObject.CompareTag("OvercrowdHuman"))
            {
                coll.GetComponent<Rigidbody>().AddForce(GetPushDirection(coll.transform) * pushForce, ForceMode.Acceleration);
            }
        }
    }


    Vector3 GetPushDirection(Transform other)
    {
        return (other.position - transform.position).normalized;
    }
}
