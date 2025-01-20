using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : MonoBehaviour
{
    [SerializeField] private Fireball fireball;
    [SerializeField] private Transform fireball_point;
    [SerializeField] private float fireball_time_attack;
    private Animator anim;
    private bool playerdetected = false;
    [SerializeField] private Transform targetplayer;



    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(RoutineAttack());
    }

   
    void Update()
    {
        RotateForDestiny();
    }


    IEnumerator RoutineAttack()
    {
        while (playerdetected)
        {
            anim.SetTrigger("atacar");
            RotateForDestiny();

            yield return new WaitForSeconds(fireball_time_attack);


        }
    }


    private void LanzarBola()
    {
        Fireball newFireball = Instantiate(fireball, fireball_point.position, Quaternion.identity);
        if (transform.localScale.x < 0)
        {
            newFireball.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        }

    protected void OnTriggerEnter2D(Collider2D elotro)
    {
        if (elotro.gameObject.CompareTag("PlayerDetection") || elotro.gameObject.CompareTag("PlayerAreaCuerpo"))
        {
            RotateForDestiny();
            playerdetected = true;
            StartCoroutine(RoutineAttack());
        }
            

        
        playerdetected = false;
    }
    private void RotateForDestiny()
    {
        if (targetplayer != null)
        {
            if (targetplayer.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

}
