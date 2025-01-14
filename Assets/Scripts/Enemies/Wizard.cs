using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] private Fireball fireball;
    [SerializeField] private Transform fireball_point;
    [SerializeField] private float fireball_time_attack;

    private Animator anim;
    private bool playerdetected = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(RoutineAttack());
    }

   
    void Update()
    {
        
    }


    IEnumerator RoutineAttack()
    {
        while (playerdetected)
        {
            anim.SetTrigger("atacar");
            yield return new WaitForSeconds(fireball_time_attack);
        }
    }


    private void LanzarBola()
    {
        Instantiate(fireball, fireball_point.position, transform.rotation);
    }

    protected void OnTriggerEnter2D(Collider2D elotro)
    {
        if (elotro.gameObject.CompareTag("PlayerDetection"))
        {
            // Debug.Log("player detectado");
            playerdetected = true;
            StartCoroutine(RoutineAttack());
        }
        else if (elotro.gameObject.CompareTag("PlayerAreaCuerpo"))
        {
            //   Debug.Log("player atravesado");
            LifeSystem sistemavidasPlayer = elotro.gameObject.GetComponent<LifeSystem>();
            sistemavidasPlayer.GetDamage(fireball.DamageFireBall);
        }
        playerdetected = false;
    }


}
