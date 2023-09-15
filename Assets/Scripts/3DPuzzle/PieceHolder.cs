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
        Debug.Log(transform.rotation.x + " " + transform.rotation.y + " " + transform.rotation.z);

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
        heldPiece.Merge(keyTransform, transform);


        transform.rotation = Quaternion.identity;

        heldPiece = storrage.GetComponentsInChildren<Transform>()[1].GetComponent<PuzzlePiece>();

        heldPiece.transform.parent = transform;
    }
}
