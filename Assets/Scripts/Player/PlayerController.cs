using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    public Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 1. Capturamos la entrada del jugador
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 2. Normalizamos para que no corra más en diagonal
        movement = movement.normalized;

        // 3. Enviamos los datos al Animator
        // .sqrMagnitude devuelve 0 si está quieto y > 0 si se mueve
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Movimiento", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }
}
