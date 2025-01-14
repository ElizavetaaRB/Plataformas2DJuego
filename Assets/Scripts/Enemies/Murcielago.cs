using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago : Enemy
{
    [SerializeField] public static int counterbat;


    public Transform[] Waypoints { get => waypoints; set => waypoints = value; }

    void Start()
    {
        destinyActual = waypoints[indexActual].position;
        StartCoroutine(Patrol());
    }



    protected IEnumerator Patrol()
    {
        while (true)
        {
            while (transform.position != destinyActual)
            {

                transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destinyActual, velocityways * Time.deltaTime);
                yield return null;
            }
            NewDestiny();
        }
    }

    protected void NewDestiny()
    {
        indexActual++;
        if (indexActual >= waypoints.Length)
        {
            indexActual = 0;
        }
        destinyActual = waypoints[indexActual].position;
        rotateForDestiny();
    }
    protected void rotateForDestiny()
    {
        if (destinyActual.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }


}
