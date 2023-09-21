using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class Dialogue : MonoBehaviour, IInteractable
{
    [SerializeField] private string startNodeName;

    public virtual void Interact(GameObject interactor)
    {
        DialogueManager.RunDialogue(startNodeName);
    }

    [YarnCommand("Dissapear")]
    public virtual void Dissapear()
    {
        Destroy(gameObject);
    }


    public void SetStartNodeName(string nodeName)
    {
        startNodeName = nodeName;
    }

    public string getToolTipText()
    {
        return "Press E/left click to talk";
    }
}