using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleLoader : MonoBehaviour, IInteractable
{
    [SerializeField]
    private KeyPuzzleManager puzzleManager;
    [SerializeField]
    private AudioClip piecePickUp;
    public int piecesToCollect = 3;

    private bool done;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (puzzleManager.finished && !done)
        {
            GetComponentInChildren<SphereCollider>().GetComponent<MeshRenderer>().material.SetInt("_On", 1);
            done = true;
        }
    }

    public void Interact(GameObject interactor)
    {
        if (puzzleManager.finished)
            return;

        if (piecesToCollect > 0)
            return;

        puzzleManager.Activate();
    }

    public void OnPieceCollected()
    {
        piecesToCollect--;
        audioSource.PlayOneShot(piecePickUp);

    }

    public bool IsPuzzleComplete()
    {
        return puzzleManager.finished;
    }

    public string getToolTipText()
    {
        if (puzzleManager.finished)
            return "";

        if (piecesToCollect > 0)
            return "missing " + piecesToCollect + " key pieces";
        return "Press E/left click to assemble key";
    }
}
