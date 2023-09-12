using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzlePiece : MonoBehaviour
{
    private void OnMouseDrag()
    {
        transform.rotation = Quaternion.Euler(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

        //transform.rotation = Quater
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
