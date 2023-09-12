using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField]
    float precision = 15f;
    [SerializeField]
    Vector3 keyRotation, thisRotation;


    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, 0.02f);
    }


    public bool isKeyRotationCorrect(Transform keyTransform)
    {
        return (keyTransform.rotation.x > keyRotation.x - precision && keyTransform.rotation.x < keyRotation.x + precision && keyTransform.rotation.y > keyRotation.y - precision && keyTransform.rotation.y < keyRotation.y + precision);
    }

    public bool isPieceRotationCorrect()
    {
        return (transform.rotation.x > thisRotation.x - precision && transform.rotation.x < thisRotation.x + precision && transform.rotation.y > thisRotation.y - precision && transform.rotation.y < thisRotation.y + precision);
    }
}
