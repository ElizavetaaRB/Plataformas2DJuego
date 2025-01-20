using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Boss_Attack : Boss_State
{

    [SerializeField] private float attackDistance;
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private Boss thisboss;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI playerlifes;
    private Transform targetplayer;
    private bool isAttack = false;

    public override void OnEnterState(BossController controller)
    {
        base.OnEnterState(controller);
    }

    public override void OnExitState()
    {
        isAttack = false;
    }

    public override void OnUpdateState()
    {
        RotateForDestiny();
        if (!isAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }
    private void OnTriggerEnter2D(Collider2D elotro)
    {
        if (elotro.TryGetComponent(out Player player))
        {
            targetplayer = player.transform;

        }
    }
    private void Petrificar()
    {
        StartCoroutine(PlayerPetri());
    }

    private IEnumerator PlayerPetri()
    {
        if (player != null)
        {
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            SpriteRenderer rb = playerRb.GetComponent<SpriteRenderer>();
            Player playerScript = player.GetComponent<Player>();
            Animator playeranim = player.GetComponent<Animator>();

            if (playerRb != null && player != null && rb !=null)
            {
                Vector2 originalVelocity = playerRb.velocity;
                playerRb.velocity = Vector2.zero;
                rb.color = Color.black;
                playerScript.enabled = false;
                playeranim.enabled = false;

                yield return new WaitForSeconds(thisboss.Petrify_duration);

                // Despetrificar al jugador
                rb.color = Color.white;
                playerRb.velocity = originalVelocity; // Restaurar la velocidad 
                playerScript.enabled = true;
                playeranim.enabled = true;
                Debug.Log("Despetrificado");

            }
        }
    }


    private IEnumerator AttackRoutine()
    {
        isAttack = true;
        Attack();
        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttack = false;
    }



    private void Attack()
    {
            Debug.Log("Ataqueee");
            Animator animboss = thisboss.GetComponent<Animator>();
            animboss.SetTrigger("JugadorEnRango");
            Petrificar();
            if (player != null)
            {

                LifeSystem sistemavidasPlayer = player.gameObject.GetComponent<LifeSystem>();
                animboss.SetTrigger("JugadorEnRango");
                sistemavidasPlayer.GetDamage(thisboss.Damage);
                if (sistemavidasPlayer.Lifes <= 0)
                {
                    playerlifes.text = "Lifes: 0";
                    sistemavidasPlayer.QuitGAME();
                }
                else
                {
                    playerlifes.text = "Lifes: " + sistemavidasPlayer.Lifes;
                }
            



        } 
        if (player != null)
        {
            if (Vector3.Distance(transform.position, targetplayer.position) > attackDistance) // estado de persecusión
            {
                controller.ChangeState(controller.Chasestate);
            }
        }
    }

    private void RotateForDestiny()
    {
        if (targetplayer.gameObject.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
    }
}
