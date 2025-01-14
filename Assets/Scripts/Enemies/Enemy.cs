using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform[] waypoints;
    [SerializeField] protected float velocityways;
    protected Vector3 destinyActual;
    protected int indexActual = 0;
    [SerializeField] protected int damage;



    protected void OnTriggerEnter2D(Collider2D elotro)
    {
        if (elotro.gameObject.CompareTag("PlayerDetection"))
        {
           // Debug.Log("player detectado");
        }
        else if (elotro.gameObject.CompareTag("PlayerAreaCuerpo"))
        {
         //   Debug.Log("player atravesado");
            LifeSystem sistemavidasPlayer = elotro.gameObject.GetComponent<LifeSystem>();
            sistemavidasPlayer.GetDamage(damage);
        }
    }

}
