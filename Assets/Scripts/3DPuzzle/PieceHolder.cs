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

    private void Update()
    {
        Debug.Log(keyTransform.rotation.x + " " + keyTransform.rotation.y);

        if (heldPiece.isKeyRotationCorrect(keyTransform) && heldPiece.isPieceRotationCorrect())
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
        transform.rotation = Quaternion.identity;

        heldPiece.transform.parent = keyTransform;

        heldPiece = storrage.GetComponentsInChildren<Transform>()[1].GetComponent<PuzzlePiece>();

        heldPiece.transform.parent = transform;
    }
}
