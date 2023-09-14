using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimbArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ladder>() != null)
            other.GetComponent<Ladder>().canClimb = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ladder>() != null)
            other.GetComponent<Ladder>().canClimb = false;
    }
}
