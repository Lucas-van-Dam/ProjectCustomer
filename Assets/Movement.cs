using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] [Range(0.0f, 0.5f)] private float mouseSmoothTime = 0.03f;
    [SerializeField] private bool cursorLock = true;
    [SerializeField] private float mouseSensitivity = 3.5f;
    [SerializeField] private float speed = 6.0f;
    [SerializeField] [Range(0.0f, 0.5f)] private float moveSmoothTime = 0.3f;

    private float velocityY;

    private float cameraCap;
    private Vector2 currentMouseDelta;
    private Vector2 currentMouseDeltaVelocity;

    private CharacterController controller;
    private Vector2 currentDir;
    private Vector2 currentDirVelocity;
    private Vector3 velocity;

    public bool recieveInput = true;


    float gravity;
    public bool isGrav = true;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!recieveInput)
            return;
        UpdateMouse();
        UpdateMove();
    }

    private void UpdateMove()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        var trans = this.transform;
        velocity = (trans.forward * currentDir.y + trans.right * currentDir.x) * speed;


        if (isGrav)
        {
            gravity -= 9.81f * Time.deltaTime;

            if (controller.isGrounded ) gravity = 0;

            velocity.y = gravity;

        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void UpdateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity,
            mouseSmoothTime);

        cameraCap -= currentMouseDelta.y * mouseSensitivity;

        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraCap;
        
        transform.Rotate(Vector3.up * (currentMouseDelta.x * mouseSensitivity));
    }

    public void Paralyse()
    {
        switch (recieveInput)
        {
            case true:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                recieveInput = false;
                break;
            
            case false:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                recieveInput = true;
                break;
        }

        
    }
}
