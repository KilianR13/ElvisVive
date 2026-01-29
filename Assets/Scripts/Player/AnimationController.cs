using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController ch; // Para obtener la X y la Y.

    [Tooltip("Velocidad máxima utilizada para normalizar el movimiento")]
    [SerializeField] private float maxSpeed = 1f;

    private Vector3 localmovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ch == null)
        {
            ch = GetComponent<CharacterController>();
        }
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        Vector3 speed = ch.velocity;
        localmovement = transform.InverseTransformDirection(speed);
        float x = localmovement.x;
        float y = localmovement.y;
        if (maxSpeed > 0)
        {
            x /= maxSpeed;
            y /= maxSpeed;
        }

        animator.SetFloat("X", x);
        animator.SetFloat("Y", y);
    }
}
