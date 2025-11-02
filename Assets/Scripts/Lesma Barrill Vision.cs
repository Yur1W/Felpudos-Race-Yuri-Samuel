using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesmaBarrillVision : LesmaBarill
{
    Rigidbody2D rb2;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    } 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isGrounded)
        {   

            Attack();
        }
    }
}
