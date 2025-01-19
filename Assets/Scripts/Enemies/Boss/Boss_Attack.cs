using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : Boss_State
{

    [SerializeField] private float attackDistance;
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private GameObject attackeff;
    [SerializeField] Boss thisboss;

    private Transform targetplayer;
    [SerializeField] GameObject player;
    private int randomattack;
    public override void OnEnterState(BossController controller)
    {
        base.OnEnterState(controller);
    }

    public override void OnExitState()
    {
    }

    public override void OnUpdateState()
    {
        StartCoroutine(AttackRoutine());   

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

            if (playerRb != null)
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
        yield return new WaitForSeconds(timeBetweenAttacks);
        Attack();
    }



    private void Attack()
    {
        //ataca
        randomattack = Random.Range(0, 2);
        StartCoroutine(EffectsAttack());
        Debug.Log(randomattack);
        if (randomattack == 1)
        {
            Petrificar();
        }
        else
        {
            if (player != null)
            {
                LifeSystem sistemavidasPlayer = player.gameObject.GetComponent<LifeSystem>();
                sistemavidasPlayer.GetDamage(thisboss.Damage);
            }



        }



    //    attackeff.enabled = false;
        if (player != null)
        {
            if (Vector3.Distance(transform.position, targetplayer.position) > attackDistance) // estado de persecusión
            {
                controller.ChangeState(controller.Chasestate);
            }
        }
    }

    private IEnumerator EffectsAttack()
    {
        attackeff.SetActive(true);
        yield return new WaitForSeconds(2.5f);
       // attackeff.SetActive(false);
    }

}
