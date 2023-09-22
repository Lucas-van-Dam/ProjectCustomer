using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePuzzlePiece : MonoBehaviour, IInteractable
{
    [SerializeField]
    PuzzleLoader loader;
    
    public void Interact(GameObject interactor)
    {
        loader.OnPieceCollected();

        GameObject.Destroy(gameObject);
    }

    public string getToolTipText()
    {
        return "press E/left click to collect";
    }
}
