using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesmaBarill : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    [SerializeField]
    float velocidade = 8f;
    [SerializeField]
    float jumpForce = 5f;
    float limiteDestruicaoX = -13f;
    bool isGrounded;
    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        GroundCheck();
    }
    void Mover()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        if (transform.position.x < limiteDestruicaoX)
        {
            Destroy(gameObject);

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isGrounded)
        {   
            animator.Play("Attack");
            rb.velocity = (Vector2.up * jumpForce);
        }
    }
     private void GroundCheck()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Ground")))
        { isGrounded = true; }
        else
        { isGrounded = false; }
    }
}
