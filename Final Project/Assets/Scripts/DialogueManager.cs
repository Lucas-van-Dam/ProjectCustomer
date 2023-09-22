using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    private static GameObject player;
    private static DialogueRunner dialogue;

    private void Start()
    {
        Initialize();
    }

    private static void Initialize()
    {
        dialogue = (DialogueRunner)FindObjectOfType(typeof(DialogueRunner));
        player = FindObjectOfType(typeof(Movement))?.GameObject();
        dialogue.onDialogueComplete.AddListener(End);
    }

    public static void RunDialogue(string nodeName)
    {

        if (dialogue.IsDialogueRunning)
            return;
        dialogue.StartDialogue(nodeName);
        player.GetComponent<Movement>()?.Paralyse();
    }

    private static void End()
    {
        player.GetComponent<Movement>()?.Paralyse();
    }
}
