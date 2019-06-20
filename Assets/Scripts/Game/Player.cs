using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriterenderer;

    public float runSpeed;

    bool ParadoFrente = false;
    bool ParadoTras = false;
    bool ParadoE = false;
    bool ParadoD = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movimento();
    }

    public void Movimento()
    {
        if (Input.GetKey("d"))
        {
            transform.Translate(new Vector2(runSpeed, rb2d.velocity.y));
            animator.Play("AndaL");
            spriterenderer.flipX = true;
            ParadoTras = false;
            ParadoFrente = false;
            ParadoD = false;
            ParadoE = true;
        }
        else if (Input.GetKey("a"))
        {
            transform.Translate(new Vector2(-runSpeed, rb2d.velocity.y));
            animator.Play("AndaL");
            spriterenderer.flipX = false;
            ParadoTras = false;
            ParadoFrente = false;
            ParadoD = true;
            ParadoE = false;
        }
        else if (Input.GetKey("w"))
        {
            transform.Translate(new Vector2(rb2d.velocity.x, runSpeed));
            animator.Play("AndaT");
            ParadoTras = true;
            ParadoFrente = false;
            ParadoD = false;
            ParadoE = false;
        }
        else if (Input.GetKey("s"))
        {
            transform.Translate(new Vector2(rb2d.velocity.x, -runSpeed));
            animator.Play("AndaF");
            ParadoTras = false;
            ParadoFrente = true;
            ParadoD = false;
            ParadoE = false;
        }
        else
        {
            if (ParadoE)
            {
                animator.Play("PL");
                spriterenderer.flipX = true;
            }
            if (ParadoD)
            {
                animator.Play("PL");
                spriterenderer.flipX = false;
            }
            if (ParadoFrente)
            {
                animator.Play("PF");
            }
            if (ParadoTras)
            {
                animator.Play("PT");
            }
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}
