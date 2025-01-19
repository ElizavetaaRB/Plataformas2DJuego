using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using UnityEngine;

public class Boss_Idle : Boss_State
{

    [SerializeField] private Transform[] route;
    [SerializeField] private float speed;


    private Vector3 currentDestination;
    private int currentDestinationindex = 0;
    public override void OnEnterState(BossController controller)
    {
        base.OnEnterState(controller);

        currentDestination = route[currentDestinationindex].position;
    }
    public override void OnExitState()
    {
        
    }

    public override void OnUpdateState()
    {
        transform.position = Vector3.MoveTowards(transform.position,currentDestination,speed * Time.deltaTime);
        if (currentDestination == transform.position)
        {
            CalculateNewDestination();
        }

    }

    private void CalculateNewDestination()
    {
        currentDestinationindex++;
        if (currentDestinationindex > (route.Length-1))
        {
            currentDestinationindex = 0;
        }
        currentDestination = route[currentDestinationindex].position;
        rotateForDestiny();
    }


    private void OnTriggerEnter2D(Collider2D elotro)
    {
        if (elotro.TryGetComponent(out Player player))
        {
            controller.ChangeState(controller.Chasestate);
        }
    }

    private void rotateForDestiny()
    {
        if (currentDestination.x > transform.position.x)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            transform.localScale = new Vector3(- 2,2, 2);
        }
    }

}
