using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkingSpeed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 0.03f; // Hassasiyeti düşürdüm
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    Vector2 moveInput;
    Vector2 lookInput;
    bool jumpPressed = false; // Zıplama için

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnMove(InputValue value) => moveInput = value.Get<Vector2>();
    public void OnLook(InputValue value) => lookInput = value.Get<Vector2>();

    // Zıplama tuşuna basıldığında tetiklenir
    public void OnJump(InputValue value)
    {
        if (value.isPressed && characterController.isGrounded)
        {
            jumpPressed = true;
        }
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * moveInput.y + right * moveInput.x) * walkingSpeed;

        // Zıplama mantığı
        if (jumpPressed)
        {
            moveDirection.y = jumpSpeed;
            jumpPressed = false; // Tekrar zıplamayı sıfırla
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Yerçekimi
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        // Bakış
        rotationX += -lookInput.y * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, lookInput.x * lookSpeed, 0);
    }
}
