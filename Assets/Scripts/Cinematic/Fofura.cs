using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fofura : MonoBehaviour

{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    float input;
    float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
       
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Uruca"))
        {
            anim.Play("Got");
            input = 1;
            sprite.flipX = true;
            
        }
    }
}
