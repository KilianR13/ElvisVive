using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    public LensDistortion lensDistortion;

    [Header("Movimiento")]
    public float moveSpeed = 5f;
    private float originalMoveSpeed;

    public float MovementPenalty;

    [Header("Salto")]
    public float jumpHeight = 30f;
    public float gravity = -9.81f;
    public float fallMultiplier = 1.5f;

    private bool Salto;
    public bool enSuelo;

    private bool saltoTriggerActivo;

    [Header("Jump Buffer")]
    public float jumpBufferTime = 0.3f;
    private float jumpBufferCounter;

    [Header("Camera")]
    [SerializeField] private Transform camTransform;
    [SerializeField] private bool shouldFaceDirection = false;

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
        // Usa el InputSystem antiguo para registrar los saltos
        HandleJumpOldInput();
        
        // Mueve al jugador en base a la dirección de la cámara
        HandlePlayerMovementAndRotation();

        // Controla varias cosas sobre la gravedad del jugador
        HandleGravityAndJump();
        Sprint();
        enSuelo = controller.isGrounded;
        Vector3 speed = controller.velocity;
        Vector3 localMovement = controller.transform.InverseTransformDirection(speed);

        animator.SetFloat("X", localMovement.x);
        animator.SetFloat("Y", speed.y);
        animator.SetFloat("Z", localMovement.z);

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded && !saltoTriggerActivo)
        {
            animator.SetTrigger("Salto");
        }
            

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("SueloCerca", false);
        }

        animator.SetBool("EnSuelo", enSuelo);

        this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Volume>().profile.TryGet<LensDistortion>(out lensDistortion);

        MovementPenalty =  (((float)lensDistortion.intensity * -1) /2) + 1;

        Debug.Log($"movement penalty {MovementPenalty}");
    }

    private void HandlePlayerMovementAndRotation()
    {
        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;
        Vector3 finalMove = moveDirection * moveSpeed * MovementPenalty;
        finalMove.y = velocity.y;
        controller.Move(finalMove * Time.deltaTime);

        if(shouldFaceDirection && moveDirection.sqrMagnitude > 0.001)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
        }
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

    private void HandleJumpOldInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Salto = true;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }


    private void HandleGravityAndJump()
    {
        if (enSuelo && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (enSuelo && Salto)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("Salto", Salto);
            Salto = false;
            enSuelo = false;
        }

        velocity.y += gravity * Time.deltaTime;
    }
    // private void HandleGravityAndJump()
    // {
    //     if (enSuelo)
    //     {
    //         velocity.y = -2f; // mantiene pegado al suelo
    //     }
        
    //     if (enSuelo && Salto)
    //     {
    //         // velocity.y = 0f;
    //         velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

    //         animator.SetBool("Salto", Salto);
           
    //         Salto = false;

    //         enSuelo = false;
    //     }
    // }

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
