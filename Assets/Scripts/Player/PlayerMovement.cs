using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")] 
    public float moveSpeed = 5f;
    public int minSpeed = 1;

    [Header("Salto / Gravedad")] 
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    private CharacterController characterController;

    [SerializeField] private Vector2 moveInput;
    private float verticalVelocity;

    // [SerializeField] private Animator animator;
    private float verticalSpeed;
    private float lastYPosition;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // animator = GetComponent<Animator>();
        lastYPosition = transform.position.y;
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // public void OnCancel()
    // {
    //     Cursor.visible = true;
    //     Cursor.lockState = CursorLockMode.None;
    // }

    // Update is called once per frame
    void Update()
    {
        if (characterController == null)
        {
            return;
        }
        ControlMovimiento();
        // WalkSFXFunction();
        AnimationControl();
    }

    private void LateUpdate()
    {
        float currentY = transform.position.y;
        verticalSpeed = (currentY - lastYPosition) / Time.deltaTime;
        lastYPosition = currentY;
    }


    // void WalkSFXFunction()
    // {
    //     if (walkSFX == null)
    //     {
    //         return;
    //     }
    //     Vector3 v = characterController.velocity;
    //     v.y = 0;
    //     bool walking = characterController.isGrounded && v.magnitude > minSpeed;
    //     if (walking)
    //     {
    //         if (!walkSFX.isPlaying)
    //         {
    //             walkSFX.Play();    
    //         }
    //     }
    //     else 
    //     {
    //         if (walkSFX.isPlaying)
    //         {
    //             walkSFX.Stop();
    //         }
    //     }
    // }


    public void OnJump(InputValue value) 
    { 
        Debug.Log("hola");
    } 
    
    private void ControlMovimiento()
    { 
        bool isGrounded = characterController.isGrounded; 
    
        //Reset vertical al tocar suelo 
        if (isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        } 
    
        //Movimiento local XZ 
        Vector3 localMove = new Vector3(moveInput.x, 0, moveInput.y); 
    
        //convertir de local a mundo 
        Vector3 worldMove = transform.TransformDirection(localMove); 
        if (worldMove.sqrMagnitude > 1f) 
        { 
            worldMove.Normalize();
        } 
        Vector3 horizontalVelocity = worldMove * moveSpeed; 
    
        //Salto 
        // if (isGrounded )
        // { 
        //     jumpSFX.Play(); 
        //     animator.SetTrigger("Jump");
        //     verticalVelocity=Mathf.Sqrt(jumpHeight * -2f * gravity); 
        //     jumpRequested = false;
            
        // } 
    
        // Gravedad dinámica 
        float currentGravity = gravity;
        if (verticalVelocity < 0f)
        { 
            currentGravity *= 1.2f;
        } 
        else 
        { 
            currentGravity = gravity;
        } 
        verticalVelocity += currentGravity * Time.deltaTime; 
    
        //Salto 
        verticalVelocity += gravity * Time.deltaTime;
        horizontalVelocity.y = verticalVelocity;
        characterController.Move(horizontalVelocity * Time.deltaTime); 
    }

    private void AnimationControl()
    {
        Vector3 speed = characterController.velocity;
        Vector3 localMovement = characterController.transform.InverseTransformDirection(speed);

        // animator.SetFloat("X_side", localMovement.x);
        // animator.SetFloat("Z_fwd_bwd", localMovement.z);
        // animator.SetFloat("Y_jump", localMovement.y);
        // animator.SetBool("OnFloor", characterController.isGrounded);
    }

}