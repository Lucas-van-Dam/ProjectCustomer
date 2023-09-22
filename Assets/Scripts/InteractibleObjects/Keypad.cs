using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour, IInteractable
{
    [SerializeField] private string tooltipText;
    
    [SerializeField] private GameObject keypadUI;
    [SerializeField] private GameObject folderUI;

    private bool folderAdded = false;

    public void Interact(GameObject interactor)
    {
        interactor.GetComponent<Movement>().Paralyse();
        keypadUI.SetActive(true);
        keypadUI.GetComponent<KeypadUI>().Enable(interactor, this);

        if (folderAdded)
        {
            folderUI.SetActive(true);
        }
    }

    public void FolderCollected()
    {
        folderAdded = true;
    }

    public string getToolTipText()
    {
        return "Press E/left click to open keypad";
    }

}
