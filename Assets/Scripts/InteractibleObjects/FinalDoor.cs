using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject interactor)
    {
        interactor.GetComponent<Movement>().Paralyse();
        
    }

    public string getToolTipText()
    {
        throw new System.NotImplementedException();
    }
}
