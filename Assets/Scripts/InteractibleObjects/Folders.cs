using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Folders : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject folderUI;

    public void Interact(GameObject interactor)
    {
        folderUI.SetActive(true);
        folderUI.GetComponent<FoldersUI>().Enable(interactor);
        interactor.GetComponent<Movement>().Paralyse();
    }

    public string getToolTipText()
    {
        return "inspect";
    }
}
