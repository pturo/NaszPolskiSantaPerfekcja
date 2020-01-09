using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    public VirtualJoystick joystick;
    CharacterController characterController;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotationSpeed = 0.1f;
    private Vector3 moveDirection = Vector3.zero;

    // rotation that occurs in angles per second holding down input
    public float rotationRate = 3.0f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(joystick.Horizontal(), 0.0f, joystick.Vertical());
            moveDirection *= speed;

            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Turn the camera
        Turn();
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
}