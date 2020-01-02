using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public VirtualJoystick joystick;
    CharacterController characterController;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotationSpeed = 5;
    private Vector3 moveDirection = Vector3.zero;

    // rotation that occurs in angles per second holding down input
    public float rotationRate = 3.0f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection = new Vector3(joystick.Horizontal(), 0.0f, joystick.Vertical());
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        Jump();

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Turn the camera
        Turn();
        ShootPresent();
    }

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;
    }

    private void Turn()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touching at: " + touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Quaternion dY = Quaternion.Euler(0f, -touch.deltaPosition.x * rotationSpeed, 0f);
                transform.rotation = dY * transform.rotation;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Touch ended.");
            }
        }
    }

    public void ShootPresent()
    {
        GameObject present = ObjectPooler.SharedInstance.GetPooledObject();
        if (Input.GetButton("Mouse X"))
        {
            if (present != null)
            {
                present.SetActive(true);
            }
        }
    }
}