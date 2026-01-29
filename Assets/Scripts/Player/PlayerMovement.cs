using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;

    [Header("Salto")]
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float fallMultiplier = 1.5f;

    [Header("Jump Buffer")]
    public float jumpBufferTime = 0.15f;
    private float jumpBufferCounter;


    private CharacterController controller;
    [SerializeField] private Animator animator;
    private Vector2 moveInput;
    private Vector3 velocity;
    private bool jumpRequested;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleGravityAndJump();
        AnimationControl();
        controller.Move(velocity * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumpBufferCounter = jumpBufferTime;
        }
    }


    private void HandleMovement()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        move = transform.TransformDirection(move);
        move = Vector3.ClampMagnitude(move, 1f);

        velocity.x = move.x * moveSpeed;
        velocity.z = move.z * moveSpeed;
    }

    private void HandleGravityAndJump()
    {
        bool grounded = controller.isGrounded;

        if (grounded && velocity.y < 0f)
        {
            velocity.y = -2f; // mantiene pegado al suelo
        }

        if (grounded && jumpBufferCounter > 0f)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpBufferCounter = 0f;
        }


        // Gravedad
        float currentGravity = gravity;
        if (velocity.y < 0f)
            currentGravity *= fallMultiplier;

        velocity.y += currentGravity * Time.deltaTime;
        if (jumpBufferCounter > 0f)
            jumpBufferCounter -= Time.deltaTime;

    }

    private void AnimationControl()
    {
        Vector3 speed = controller.velocity;
        Vector3 localMovement = controller.transform.InverseTransformDirection(speed);

        animator.SetFloat("X", localMovement.x);
        animator.SetFloat("Y", localMovement.z);
    }
}
