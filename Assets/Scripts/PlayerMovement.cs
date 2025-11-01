using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float health = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        horizontalInput = 0; ;

        spriteRenderer.flipX = horizontalInput > 0;
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void TakeDamage()
    {
        Debug.Log("Player took damage! Vida : " + health );
        health -= 1f;
        StartCoroutine(BlinkEffect());
        if (health <= 0f)
        {
            Debug.Log("Player is dead!");
        }
    }
    private IEnumerator BlinkEffect()
    {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        
    }
}
