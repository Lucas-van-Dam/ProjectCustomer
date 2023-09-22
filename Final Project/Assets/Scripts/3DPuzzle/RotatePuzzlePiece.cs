using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzlePiece : MonoBehaviour
{
    [SerializeField]
    static float rotationSpeed = 1;

    bool rotating = false;
    [SerializeField]
    bool left;

    Vector2 rotate = Vector2.zero;

    public bool activated = false;

    void Update()
    {
        if (!activated)
            return;

        if (Input.GetMouseButtonDown(0) && ((Input.mousePosition.x > Screen.width/2 && !left) || (Input.mousePosition.x < Screen.width / 2 && left)))
        {
            rotating = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rotating = false;
        }

        if (rotating)
        {
            rotate = new Vector2(rotate.x + Input.GetAxis("Mouse Y") * rotationSpeed, rotate.y - Input.GetAxis("Mouse X") * rotationSpeed);

            transform.rotation = Quaternion.Euler(rotate.x, rotate.y, 0);
        }
    }
}
