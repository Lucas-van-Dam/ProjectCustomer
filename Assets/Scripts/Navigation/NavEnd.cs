using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ChaseObject>() != null)
        {
            other.GetComponent<ChaseObject>().isFollowActive = false;
            gameObject.SetActive(false);
            other.GetComponent<Dialogue>().SetStartNodeName("KidStops");
        }
    }

    
}
