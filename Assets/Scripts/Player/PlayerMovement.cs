using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;
    private float originalMoveSpeed;

    [Header("Salto")]
    public float jumpHeight = 30f;
    public float gravity = -9.81f;
    public float fallMultiplier = 1.5f;

    private bool Salto;
    public bool enSuelo;

    [Header("Jump Buffer")]
    public float jumpBufferTime = 0.3f;
    private float jumpBufferCounter;


    public CharacterController controller;
    [SerializeField] private Animator animator;
    private Vector2 moveInput;
    private Vector3 velocity;
    private bool jumpRequested;

    void Awake()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterController>();    
        }
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        OldInput();
        HandleMovement();
        HandleGravityAndJump();
        Sprint();
        controller.Move(velocity * Time.deltaTime);
        enSuelo = controller.isGrounded;
        Vector3 speed = controller.velocity;
        Vector3 localMovement = controller.transform.InverseTransformDirection(speed);
        Debug.Log($"Speed: {speed}, localMovement: {localMovement}");

        animator.SetFloat("X", localMovement.x);
        animator.SetFloat("Y", speed.y);
        animator.SetFloat("Z", localMovement.z);

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
            animator.SetTrigger("Salto");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("SueloCerca", false);
        }

        animator.SetBool("EnSuelo", enSuelo);
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

    private void OldInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Salto = true;
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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }


    /*private void HandleGravityAndJump()
    {
        bool grounded = controller.isGrounded;

        if (grounded && velocity.y < 0f)
        {
            velocity.y = -2f; // mantiene pegado al suelo
        }

        if (grounded && jumpBufferCounter > 0f)

        {
            // velocity.y = 0f;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpBufferCounter = 0f;
        }


        // Gravedad
        float currentGravity = gravity;
        if (velocity.y < 0f)
            currentGravity *= fallMultiplier;

        velocity.y += currentGravity * Time.deltaTime;
        if (jumpBufferCounter > 0f)
        {
            jumpBufferCounter -= Time.deltaTime;
            StartCoroutine(SetLateSueloCerca());
        }
    }*/

    private void HandleGravityAndJump()
    {
        Debug.Log($"enSuelo {enSuelo}");

        Debug.Log($"Salto {Salto}");

        if (enSuelo)
        {
            velocity.y = -2f; // mantiene pegado al suelo
        }
        
        if (enSuelo && Salto)
        {
            // velocity.y = 0f;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            animator.SetBool("Salto", Salto);
           
            Salto = false;

            enSuelo = false;
        }
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = originalMoveSpeed * 2;
        }

        else
        {
            moveSpeed = originalMoveSpeed;
        }
    }
}
