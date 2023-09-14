using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField]
    Vector3 precision, keyRotation, thisRotation, offset;



    Vector3 targetPos = Vector3.zero;

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, 0.02f);
    }


    public bool isKeyRotationCorrect(Transform keyTransform)
    {
        return (keyTransform.rotation.x > keyRotation.x - precision.x && keyTransform.rotation.x < keyRotation.x + precision.x && keyTransform.rotation.y > keyRotation.y - precision.y && keyTransform.rotation.y < keyRotation.y + precision.y);
    }

    public bool isPieceRotationCorrect()
    {
        return (transform.rotation.x > thisRotation.x - precision.x && transform.rotation.x < thisRotation.x + precision.x && transform.rotation.y > thisRotation.y - precision.y && transform.rotation.y < thisRotation.y + precision.y);
    }
    
    public void Merge(Transform keyTransform, Transform holderTransform)
    {
        targetPos = offset;

        transform.parent = keyTransform;

        transform.rotation = new Quaternion(holderTransform.rotation.x, holderTransform.rotation.y, holderTransform.rotation.z, 1);

    }

}
