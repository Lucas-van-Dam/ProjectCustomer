using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour, IInteractable
{
    [SerializeField]
    Door door;

    public void Interact(GameObject interactor)
    {
        door.Locked = false;
    }

    public string getToolTipText()
    {
        return " to unlock door";
    }
}
