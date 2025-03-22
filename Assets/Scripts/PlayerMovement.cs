// Autor: Diego Carreón Aguirre
// Tutor : Roberto Martínez Román

using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Definieno las variables de velocidad en X y Y y la variable de la fuerza del salto inicial
    [SerializeField]
    private float VelocidadY;
    [SerializeField]
    private float VelocidadX;

    [SerializeField]
    private float fuerzaSaltoInicial = 5f; 

    // Variable para acceder al componente Rigidbody2D
    private Rigidbody2D rb;
    private SpriteRenderer sr; // Variable para acceder al componente SpriteRenderer

    private bool enPiso = false; // Variable para saber si el personaje está en el piso o no
    private bool saltando = false; // Nueva variable para controlar el estado de salto

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Inicializar rb
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>(); // Inicializar sr
    }

    // Update is called once per frame (60FPS)
    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movHorizontal * VelocidadX, rb.linearVelocity.y);

        float movVertical = Input.GetAxis("Vertical");
        if (movVertical > 0 && enPiso && !saltando)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSaltoInicial);
            saltando = true; // Marcar que el personaje está saltando
        }
        else if (movVertical == 0)
        {
            saltando = false; // Resetear el estado de salto cuando se suelta la tecla de salto
        }

        Flip(); // Llamar a la función Flip para girar el sprite del personaje
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        enPiso = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        enPiso = false;
    }

    // Función para girar el sprite del personaje
    void Flip()
    {
        if (rb.linearVelocity.x > 0)
        {
            sr.flipX = false;
        }
        else if (rb.linearVelocity.x < 0)
        {
            sr.flipX = true;
        }
    }
}