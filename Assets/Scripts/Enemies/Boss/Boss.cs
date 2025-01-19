using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Boss : MonoBehaviour
{
    [Header("Attack system")]
    [SerializeField] private int damage;
    [SerializeField] private float petrify_duration;
    [SerializeField] private GameObject player;


    [SerializeField] private Transform attackpoint;
    [SerializeField] private float attackradius;
    [SerializeField] private LayerMask whatisDamage;




    private Animator bossanimator;
    private Animator playerAnimator;
    private bool petri;
    private bool yahasidopetri = false;
    void Start()
    {
        bossanimator = GetComponent<Animator>();
        playerAnimator = player.GetComponent<Animator>();
        petri = false;
    }

    
    void Update()
    {
        if (!yahasidopetri)
        {
            Ejecutar();
        }

    }

    private void Ejecutar()
    {
        Collider2D collisdetected = Physics2D.OverlapCircle(attackpoint.position, attackradius, whatisDamage);
        if (collisdetected != null)
        {
            yahasidopetri = true;
            // bossanimator.SetBool("JugadorDetectado", true);
            bossanimator.SetTrigger("JugadorEnRango");
            Debug.Log("En deteccion");

            Petrificar();
          //  Attack();
        }

    }

    private void Attack()
    {
        if (petri)
        {
            Debug.Log("Ataqueeee");
            bossanimator.SetTrigger("JugadorEnRango");
         /* LifeSystem sistemavidasPlayer = player.gameObject.GetComponent<LifeSystem>();
            sistemavidasPlayer.GetDamage(damage); */
        }
    }

    private void Petrificar()
    {
        StartCoroutine(PlayerPetri());
    }

    private IEnumerator PlayerPetri()
    {
        if(player != null)
        {
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            SpriteRenderer rb = playerRb.GetComponent<SpriteRenderer>();
            Player playerScript = player.GetComponent<Player>();

            if (playerRb != null)
            {
                Vector2 originalVelocity = playerRb.velocity;
                playerRb.velocity = Vector2.zero;
                rb.color = Color.black;
                playerScript.enabled = false;
                playerAnimator.enabled = false;
                petri = true;

                yield return new WaitForSeconds(petrify_duration);

                // Despetrificar al jugador
                rb.color = Color.white;
                playerRb.velocity = originalVelocity; // Restaurar la velocidad 
                playerScript.enabled = true;
                playerAnimator.enabled = true;
                Debug.Log("Despetrificado");
                petri = false;

            }
        }
    }

    private void OnDrawGizmos() // dibujar el circulo de ataque del boss
    {
        Gizmos.DrawSphere(attackpoint.position, attackradius);
    }

}
