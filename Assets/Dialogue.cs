using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

[RequireComponent(typeof(DialogueRunner))]
public class Dialogue : MonoBehaviour, IInteractable
{

    [SerializeField] private DialogueRunner dialogue;
    [SerializeField] private string startNodeName;

    private GameObject player;
    public void Interact(GameObject interactor)
    {
        if (dialogue.IsDialogueRunning)
            return;
        dialogue.StartDialogue(startNodeName);
        player = interactor;
        player.GetComponent<Movement>()?.Paralyse();
        dialogue.onDialogueComplete.AddListener(End);
    }

    [YarnCommand("End")]
    public static void EndDialogue()
    {
        var move = (Movement)FindObjectOfType(typeof(Movement));
        move.Paralyse();
        
    }

    public void End()
    {
        Debug.Log("END");
        player.GetComponent<Movement>()?.Paralyse();
        
    }

    [YarnCommand("Dissapear")]
    public virtual void Dissapear()
    {
        Destroy(gameObject);
    }

    public string getToolTipText() { return "talk"; }

}
