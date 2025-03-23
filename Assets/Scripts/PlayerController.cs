// AUTOR DIEGO CARREÓN AGUIRRE
// TUTOR ROBERTO MARTÍNEZ ROMÁN
// Ayuda para el movimiento del jugador y la física del salto tomada del siguiente blog 
// https://blog.terresquall.com/2023/04/creating-a-metroidvania-like-hollow-knight-part-1/

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Horizontal Movement Settings")]
    [SerializeField] private float walkSpeed = 1; // Velocidad de movimiento del jugador
    
    [Header ("Ground Check Settings")]
    [SerializeField] private float jumpForce = 35; // Fuerza de salto del jugador
    [SerializeField] private Transform groundCheckPoint; // Punto de chequeo de suelo
    [SerializeField] private float groundCheckY = 0.2f; // Distancia de chequeo de suelo
    [SerializeField] private LayerMask whatIsGround; // Layer de suelo
    [SerializeField] private float groundCheckX = 0.5f; // Distancia de chequeo de suelo en X

    // Variables privadas para el movimiento del jugador y la física
    private float xAxis;
    private Rigidbody2D rb;
    private Animator anim;

    // 
    public static PlayerController Instance;

    void Awake() // Se ejecuta antes de Start y después de la creación del objeto 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        Move();
        Jump();
        Flip();
    }

    void GetInputs() // Obtiene los inputs del jugador
    {
        xAxis = Input.GetAxis("Horizontal");
    }

    void Flip() // Voltea al jugador en el eje X
    {
        if (xAxis < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if (xAxis > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
    }

    private void Move()     // Mueve al jugador en el eje X
    {
        rb.linearVelocity = new Vector2(xAxis * walkSpeed, rb.linearVelocity.y);
        anim.SetBool("Walking", rb.linearVelocity.x != 0 && Grounded());
    }

    public bool Grounded() // Checa si el jugador está en el suelo
    {
       if (Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatIsGround) 
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround) 
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(-groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround))
       {
           return true;
       }
       else
       {
           return false;
       }
    }

    void Jump() // Salto del jugador
    {
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
        if (Input.GetButtonDown("Jump") && Grounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce);
        }

        anim.SetBool("Jumping", !Grounded());
    }
}

