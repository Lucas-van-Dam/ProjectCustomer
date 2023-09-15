using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField]
    Vector3 precision, keyRotation, thisRotation, offset, offsetRotation;



    Vector3 targetPos = Vector3.zero;

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, 0.02f);
    }


    public bool isKeyRotationCorrect(Transform keyTransform)
    {

        return (keyTransform.rotation.x > keyRotation.x - precision.x && keyTransform.rotation.x < keyRotation.x + precision.x && keyTransform.rotation.y > keyRotation.y - precision.y && keyTransform.rotation.y < keyRotation.y + precision.y) || (-keyTransform.rotation.x > keyRotation.x - precision.x && -keyTransform.rotation.x < keyRotation.x + precision.x && -keyTransform.rotation.y > keyRotation.y - precision.y && -keyTransform.rotation.y < keyRotation.y + precision.y);
    }

    public bool isPieceRotationCorrect()
    {
        return (transform.parent.rotation.x > thisRotation.x - precision.x && transform.parent.rotation.x < thisRotation.x + precision.x && transform.parent.rotation.y > thisRotation.y - precision.y && transform.parent.rotation.y < thisRotation.y + precision.y) || (-transform.parent.rotation.x > thisRotation.x - precision.x && -transform.parent.rotation.x < thisRotation.x + precision.x && -transform.parent.rotation.y > thisRotation.y - precision.y && -transform.parent.rotation.y < thisRotation.y + precision.y);
    }
    
    public void Merge(Transform keyTransform, Transform holderTransform)
    {
        transform.parent = keyTransform;

        targetPos = offset;

        //transform.rotation = new Quaternion(-90, 0, 0, 1);

        //keyTransform.rotation = new Quaternion(keyRotation.x, keyRotation.y, keyRotation.z, 1);

        //transform.rotation = new Quaternion(holderTransform.rotation.x + transform.rotation.x, holderTransform.rotation.y + transform.rotation.y, holderTransform.rotation.z + transform.rotation.z, 1);

    }

}
