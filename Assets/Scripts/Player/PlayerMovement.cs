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
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float fallMultiplier = 1.5f;

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
        HandleMovement();
        HandleGravityAndJump();
        Sprint();
        controller.Move(velocity * Time.deltaTime);
        enSuelo = controller.isGrounded;
        Vector3 speed = controller.velocity;
        Vector3 localMovement = controller.transform.InverseTransformDirection(speed);
        Debug.Log($"Speed: {speed}, localMovement: {localMovement}");

        animator.SetFloat("X", localMovement.x);
        animator.SetFloat("Y", localMovement.y);
        animator.SetFloat("Z", localMovement.z);

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
            animator.SetTrigger("Salto");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("SueloCerca", false);
        }

        animator.SetBool("EnSuelo", controller.isGrounded);
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

    private void OldInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
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


    private IEnumerator SetLateSueloCerca()
    {

        yield return new WaitForSeconds(2f);

        //este raycast detecta el suelo con algo de margen

        if(VicGenLib.Logic.RayCasts.SimpleCast(this.gameObject, Vector3.down, 0.5f))
        {
            animator.SetBool("SueloCerca", true);
        }

        else
        {
            animator.SetBool("SueloCerca", false);
        }
    }
}
