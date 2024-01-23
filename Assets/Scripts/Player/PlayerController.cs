using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float lookSpeed = 0.5f;

    private Vector3 lookDirection = Vector3.zero;
    private Rigidbody rigidBody;
    private Quaternion currentRotation;
    private bool canMove = true;
    private float currentSpeed;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentRotation = transform.rotation;
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        currentSpeed = canMove ? (isRunning ? runSpeed : walkSpeed) : 0;
        lookDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rigidBody.velocity = lookDirection * currentSpeed;

        bool isMoving =
            Input.GetAxisRaw("Horizontal") != 0 ||
            Input.GetAxisRaw("Vertical") != 0;
        if (isMoving && lookDirection != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection, transform.up);
            currentRotation = Quaternion.LerpUnclamped(
                transform.localRotation,
                lookRotation,
                lookSpeed
            );
        }
        transform.localRotation = currentRotation;
    }
}
