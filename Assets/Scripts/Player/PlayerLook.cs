using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [Header("Referencias")] public Camera cameraTransform;

    [Header("Mirar (ratón)")] public float mouseSensitivity = 120f;
    public float minPitch = -40f;
    public float maxPitch = 40f;

    private Vector2 lookInput;
    private float cameraPitch;

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float delay;


    private void Awake()
    {
        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
        }
        else
        {
            playerInput.DeactivateInput();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float yaw = transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, yaw, 0);
        cameraPitch = 0f;
        lookInput = Vector2.zero;
        StartCoroutine(reactivateInput());
    }

    

    IEnumerator reactivateInput()
    {
        yield return new WaitForSeconds(delay);
        if (playerInput != null)
        {
            playerInput.ActivateInput();   
        }
    }

    void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTransform == null)
        {
            return;
        }
        HandleLook();
    }

    private void HandleLook()
    {
        // Lee el ratón
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        // Gira el personaje en el eje X
        transform.Rotate(0f, mouseX, 0f);

        // Controla si la cámara mira hacia arriba o hacia abajo
        cameraPitch -= mouseY;
        
        // Limita lo lejos que se puede girar la cámara hacia arriba o hacia abajo.
        cameraPitch = Mathf.Clamp(cameraPitch, minPitch, maxPitch);
        cameraTransform.transform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }
}