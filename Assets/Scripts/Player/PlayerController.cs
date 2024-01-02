using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float lookSpeed = 0.5f;

    /*private Vector3 moveDirection = Vector3.zero;*/
    private Vector3 lookDirection = Vector3.zero;
    private CharacterController characterController;
    private Quaternion currentRotation;

    private bool canMove = true;
    private float currentSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
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
        /*        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);*/

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        currentSpeed = canMove ? (isRunning ? runSpeed : walkSpeed) : 0;

        /*        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
                float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
                float movementDirectionY = moveDirection.y;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);*/

        lookDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        /*lookDirection = (forward * Input.GetAxis("Vertical")) + (right * Input.GetAxis("Horizontal"));*/

        characterController.Move(lookDirection * currentSpeed * Time.deltaTime);

        bool isMoving =
            Input.GetAxisRaw("Horizontal") != 0 ||
            Input.GetAxisRaw("Vertical") != 0;
        if (isMoving)
        {
            currentRotation = Quaternion.LerpUnclamped(
                transform.localRotation,
                Quaternion.LookRotation(lookDirection, transform.up),
                lookSpeed
            );
        }

        transform.localRotation = currentRotation;

        /*        if (canMove)
                {
                    transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Horizontal") * lookSpeed, 0);
                }*/
    }
}
