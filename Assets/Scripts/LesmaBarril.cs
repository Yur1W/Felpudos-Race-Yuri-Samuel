using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesmaBarill : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    [SerializeField]
    protected float velocidade = 8f;
    [SerializeField]
    protected float jumpForce = 5f;
    protected float limiteDestruicaoX = -13f;
    protected bool isGrounded;
    protected Rigidbody2D rb;
    protected Animator animator;
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
    public void Attack()
    {   
        rb.velocity = (Vector2.up * jumpForce);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {    animator.Play("Attack");
        if (collision.gameObject.CompareTag("Player")) Destroy(gameObject);
        
    }
    private void GroundCheck()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Ground")))
        { isGrounded = true; }
        else
        { isGrounded = false; }
    }
}
