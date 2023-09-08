using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHuman : MonoBehaviour, IInteractable
{
    ChaseObject chaseObject;


    void Start()
    {
        chaseObject = GetComponent<ChaseObject>();
    }


    public void Interact(GameObject interactor)
    {
        chaseObject.isFollowActive = true;
    }


}
