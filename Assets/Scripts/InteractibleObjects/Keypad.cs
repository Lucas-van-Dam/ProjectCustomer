using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour, IInteractable
{
    [SerializeField] private string tooltipText;
    
    [SerializeField] private GameObject keypadUI;
    
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
        keypadUI.SetActive(true);
    }

    public string getToolTipText()
    {
        return tooltipText;
    }
}
