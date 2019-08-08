using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(NetworkTransform))]
[RequireComponent(typeof(NetworkIdentity))]


public class Player_Movimentação : NetworkBehaviour
{
    Animator animator;
    Rigidbody2D rigid;
    SpriteRenderer SpriteRenderer;
    public float MoveSpeed = 0.1f;
    string elementos;

   // bool Parado = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AguaMovimento();
    }
    public void AguaMovimento()
    {
        if (Input.GetKey("d"))
        {
            //switch (elementos.ToLower())
            //{
            //    case "agua":
                animator.Play("AguaLado");

            //        break;
            //    case "terra":
            //        animator.Play("TerraLado");

            //        break;
            //    case "fogo":
            //        animator.Play("FogoLado");

            //        break;
            //    case "ar":
            //        animator.Play("ArLado");

            //        break;
            //}
            transform.Translate(new Vector2(MoveSpeed, rigid.velocity.y));
            SpriteRenderer.flipX = true;

        }
        else if (Input.GetKey("a"))
        {
        //    switch (elementos.ToLower())
        //    {
        //        case "agua":
                    animator.Play("AguaLado");

            //        break;
            //    case "terra":
            //        animator.Play("TerraLado");

            //        break;
            //    case "fogo":
            //        animator.Play("FogoLado");

            //        break;
            //    case "ar":
            //        animator.Play("ArLado");

            //        break;
            //}
            transform.Translate(new Vector2(-MoveSpeed, rigid.velocity.y));
             SpriteRenderer.flipX = false;

        }
        else if (Input.GetKey("w"))
        {
            //switch (elementos.ToLower())
            //{
            //    case "agua":
                    animator.Play("AguaCima");

            //        break;
            //    case "terra":
            //        animator.Play("TerraCima");

            //        break;
            //    case "fogo":
            //        animator.Play("FogoCima");

            //        break;
            //    case "ar":
            //        animator.Play("ArCima");

            //        break;
            //}
            transform.Translate(new Vector2(rigid.velocity.x, MoveSpeed));

        }
        else if (Input.GetKey("s"))
        {
            //switch (elementos.ToLower())
            //{
            //    case "agua":
                    animator.Play("AguaBaixo");

            //        break;
            //    case "terra":
            //        animator.Play("TerraBaixo");

            //        break;
            //    case "fogo":
            //        animator.Play("FogoBaixo");

            //        break;
            //    case "ar":
            //        animator.Play("ArBaixo");

            //        break;
            //}
            transform.Translate(new Vector2(rigid.velocity.x, -MoveSpeed));
        }
        else
        {
            //switch (elementos.ToLower())
            //{
            //    case "agua":
                    animator.Play("AguaParado");

            //        break;
            //    case "terra":
            //        animator.Play("TerraParado");

            //        break;
            //    case "fogo":
            //        animator.Play("FogoParado");

            //        break;
            //    case "ar":
            //        animator.Play("ArParado");

            //        break;
            //}
            rigid.velocity = new Vector2(0, 0);

        }


    }
 
}
