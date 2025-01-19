using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : Boss_State
{

    [SerializeField] private float attackDistance;
    [SerializeField] private float timeBetweenAttacks;

    private Transform targetplayer;
    private float timer;
    public override void OnEnterState(BossController controller)
    {
        base.OnEnterState(controller);
        timer = timeBetweenAttacks;
    }

    public override void OnExitState()
    {
        
    }

    public override void OnUpdateState()
    {
        timer += Time.deltaTime;
        if ((timer > timeBetweenAttacks))
        {
            //ataca
            timer = 0f;
        }
        if (Vector3.Distance(transform.position, targetplayer.position) > attackDistance) // estado de persecusión
        {
            controller.ChangeState(controller.Chasestate);
        }
    }
    private void OnTriggerEnter2D(Collider2D elotro)
    {
        if (elotro.TryGetComponent(out Player player))
        {
            targetplayer = player.transform;

        }
    }

}
