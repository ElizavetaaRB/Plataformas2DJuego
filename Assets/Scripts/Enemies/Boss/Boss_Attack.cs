using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Boss_Attack : Boss_State
{
    [SerializeField] private float attackDistance;
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private Boss thisboss;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI playerlifes;
    private Transform targetplayer;
    private bool isAttack = false;
    private System.Random random;

    public override void OnEnterState(BossController controller)
    {
        base.OnEnterState(controller);
        random = new System.Random();
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

    private IEnumerator Petrificar()
    {
        if (player != null)
        {
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            SpriteRenderer rb = playerRb.GetComponent<SpriteRenderer>();
            Player playerScript = player.GetComponent<Player>();
            Animator playeranim = player.GetComponent<Animator>();
            Animator animboss = thisboss.GetComponent<Animator>();

            if (playerRb != null && player != null && rb != null)
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

                // Verificar si el jugador todav�a est� en el rango de ataque despu�s de despetrificar
                if (Vector3.Distance(transform.position, targetplayer.position) <= attackDistance)
                {
                    Attack();
                }
            }
        }
    }

    private void Attack()
    {
        Debug.Log("Ataqueee");
        Animator animboss = thisboss.GetComponent<Animator>();

        if (player != null)
        {
            LifeSystem sistemavidasPlayer = player.gameObject.GetComponent<LifeSystem>();
            sistemavidasPlayer.GetDamage(thisboss.Damage);

            if (sistemavidasPlayer.Lifes <= 0)
            {
                sistemavidasPlayer.QuitGAME();
            }
            else
            {
                sistemavidasPlayer.UiLifeplayer(sistemavidasPlayer.Lifes);
            }
        }
    }

    private IEnumerator AttackRoutine()
    {
        isAttack = true;
        Animator animboss = thisboss.GetComponent<Animator>();

        // Seleccionar aleatoriamente entre petrificar o atacar
        int randomAttack = Random.Range(0, 2);
        if (randomAttack == 0)
        {
            animboss.SetTrigger("JugadorEnRango");
            yield return Petrificar();
        }
        else
        {
            animboss.SetTrigger("JugadorEnRango");
            Attack();
        }

        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttack = false;
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

