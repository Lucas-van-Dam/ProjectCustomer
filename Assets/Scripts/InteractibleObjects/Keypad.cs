using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Keypad : MonoBehaviour, IInteractable
{
    [SerializeField] private string tooltipText;
    [SerializeField] private GameObject keypadUI;
    [SerializeField] private AudioClip opening;
    
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
        GetComponent<AudioSource>().PlayOneShot(opening);
        interactor.GetComponent<Movement>().Paralyse();
        keypadUI.SetActive(true);
        keypadUI.GetComponent<KeypadUI>().Enable(interactor);
    }

    public string getToolTipText()
    {
        return "Press E/left click to open keypad";
    }
}
