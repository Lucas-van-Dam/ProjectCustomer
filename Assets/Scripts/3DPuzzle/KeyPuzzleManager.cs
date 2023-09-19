using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPuzzleManager : MonoBehaviour
{
    [SerializeField]
    RotatePuzzlePiece keyHolder, pieceHolder;

    [SerializeField]
    Canvas canvas;

    [SerializeField]
    Camera playerCam;
    [SerializeField]
    GameObject puzzleCam;

    [SerializeField]
    Door door;

    [SerializeField]
    Movement player;

    public bool finished = false;

    public void Activate()
    {
        canvas.gameObject.SetActive(true);

        keyHolder.activated = true;
        pieceHolder.activated = true;
        
        player.Paralyse();

        playerCam.enabled = false;
        puzzleCam.SetActive(true);
    }


    public void FinishPuzzle()
    {
        if (!pieceHolder.GetComponent<PieceHolder>().puzzleDone)
            return;

        finished = true;

        canvas.gameObject.SetActive(false);

        keyHolder.activated = false;
        pieceHolder.activated = false;

        player.Paralyse();
        door.Locked = false;

        playerCam.enabled = true;
        puzzleCam.SetActive(false);
    }

}
