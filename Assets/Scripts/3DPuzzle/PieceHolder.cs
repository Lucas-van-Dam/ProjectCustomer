using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceHolder : MonoBehaviour
{
    [SerializeField]
    MergeButton mergeButton;

    [SerializeField]
    Transform keyTransform;

    [SerializeField]
    PuzzlePiece heldPiece = null;

    [SerializeField]
    GameObject storrage;

    public bool puzzleDone = false;

    private void Update()
    {
        //Debug.Log(transform.rotation.x + " " + transform.rotation.y + " " + transform.rotation.z);

        

        if (puzzleDone)
        {
            mergeButton.Finish();
        }
        else if (heldPiece.isKeyRotationCorrect(keyTransform) && heldPiece.isPieceRotationCorrect())
        {
            mergeButton.CanMerge();
        }
        else
        {
            mergeButton.CannotMerge();
        }
    }

    

    public void Merge()
    {
        if (puzzleDone)
            return;
        
        heldPiece.Merge(keyTransform, transform);

        transform.rotation = Quaternion.identity;

        if (storrage.GetComponentsInChildren<Transform>().Length == 1)
        {
            puzzleDone = true;
            return;
        }

        heldPiece = storrage.GetComponentsInChildren<Transform>()[1].GetComponent<PuzzlePiece>();

        heldPiece.transform.parent = transform;
    }
}
