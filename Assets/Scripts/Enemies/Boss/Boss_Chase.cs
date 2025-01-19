using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Chase : Boss_State
{
    private Transform targetplayer;

    [SerializeField] private float chasespeed;
    [SerializeField] private float chasedist;
    public override void OnEnterState(BossController controller)
    {

        base.OnEnterState(controller);
    }
    public override void OnExitState()
    {
        
    }

    public override void OnUpdateState()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetplayer.position, chasespeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetplayer.position) <= chasedist)
        {
            controller.ChangeState(controller.Attackstate);
        }
    }

    private void OnTriggerEnter2D(Collider2D elotro)
    {
        if (elotro.TryGetComponent(out Player player))
        {
            targetplayer = player.transform;

        }
    }


    private void OnTriggerExit2D(Collider2D elotro)
    {
        if (elotro.TryGetComponent(out Player player))
        {
            controller.ChangeState(controller.Idlestate);

        }
    }
}
