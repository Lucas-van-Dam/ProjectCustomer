using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Folders : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject folderUI;
    [SerializeField] private AudioClip folderSlide;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Interact(GameObject interactor)
    {
        folderUI.SetActive(true);
        audioSource.PlayOneShot(folderSlide);
        folderUI.GetComponent<FoldersUI>().Enable(interactor);
        interactor.GetComponent<Movement>().Paralyse();
    }

    public string getToolTipText()
    {
        return "Press E/left click to inspect";
    }

    public void Delete()
    {
        GameObject.Destroy(gameObject);
    }
}
