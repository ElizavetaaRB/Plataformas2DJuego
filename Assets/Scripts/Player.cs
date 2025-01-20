using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputH;
    [Header("Movement system")]
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask whatisJump;
    [SerializeField] private Transform feetPlayer;
    [SerializeField] private float jumpdistance;

    [Header("Attack system")]
    [SerializeField] private Transform attackpoint;
    [SerializeField] private float attackradius;
    [SerializeField] private LayerMask whatisDamage;
    [SerializeField] private int attackdamage;

    [Header("Interaction system")]
    [SerializeField] private Transform pointDetection;
    [SerializeField] private float radioDetection;
    [SerializeField] private LayerMask whatisInteraction;



    private Animator animatorplayer;

    public float FuerzaSalto { get => fuerzaSalto; set => fuerzaSalto = value; }
    public int Attackdamage { get => attackdamage; set => attackdamage = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorplayer = GetComponent<Animator>();
    }


    void Update()
    {
        inputH = Input.GetAxisRaw("Horizontal"); // solo movimiento horizontal y el vertical solo para saltar 
        rb.velocity = new Vector2(inputH * velocidadMovimiento, rb.velocity.y) ; //es como un translate respetando las fisicas 
        Interaction();
        Running();
        Jump();
        AnimationAttack();

    }

    private void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D col = Physics2D.OverlapCircle(pointDetection.position, radioDetection, whatisInteraction);
            if (col != null) {
                if ((col.TryGetComponent(out IInteractuable interactuable)))
                {
                    interactuable.Interactuar();
                }
            }


        }
    }





    private void AnimationAttack()
    {
        if (Input.GetMouseButtonDown(0)) // attack click izquierdo
        {
            animatorplayer.SetTrigger("attack");
            
        }
    }


    private void Attack()
    {
       Collider2D[] collidersdetected = Physics2D.OverlapCircleAll(attackpoint.position, attackradius, whatisDamage);
        foreach (Collider2D item in collidersdetected)
        {
            LifeSystem lifesystem = item.gameObject.GetComponent<LifeSystem>();
            lifesystem.GetDamage(attackdamage);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnFloor()) // jump
        {
            rb.AddForce(new Vector2(0,1) * fuerzaSalto, ForceMode2D.Impulse);
            animatorplayer.SetTrigger("jump");
        } 
    }

    private bool OnFloor()
    {
       bool touch =  Physics2D.Raycast(feetPlayer.position, Vector3.down, jumpdistance, whatisJump);
        Debug.DrawRay(feetPlayer.position, Vector3.down, Color.red, 0.3f);
        return touch;
    }




    private void Running()
    {
        if (inputH != 0) // correr
        {
            animatorplayer.SetBool("running", true);
            if (inputH > 0) //derecha
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else //izquierda
            {
                this.gameObject.transform.eulerAngles = new Vector3(0,180,0);
            }

        }
        else
        {
            animatorplayer.SetBool("running", false);
        }
    }



    private void OnDrawGizmos() // dibujar el circulo de ataque del jugador
    {
        Gizmos.DrawSphere(attackpoint.position, attackradius);
    }


    private void OnCollisionEnter2D(Collision2D elotro)
    {
        if (elotro.gameObject.CompareTag("Dead"))
        {
            LifeSystem sistemavidasPlayer = this.gameObject.GetComponent<LifeSystem>();
            Destroy(this.gameObject);
            sistemavidasPlayer.QuitGAME();
        }
    }


}
