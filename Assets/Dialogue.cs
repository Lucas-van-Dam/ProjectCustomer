using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class Dialogue : MonoBehaviour, IInteractable
{

    [SerializeField] private DialogueRunner dialogue;

    private GameObject player;
    public void Interact(GameObject interactor)
    {
        if (dialogue.IsDialogueRunning)
            return;
        dialogue.StartDialogue("Start");
        player = interactor;
        player.GetComponent<Movement>()?.Paralyse();
    }
    
    [YarnCommand("End")]
    public static void EndDialogue()
    {
        var move = (Movement)FindObjectOfType(typeof(Movement));
        move.Paralyse();
    }
}
