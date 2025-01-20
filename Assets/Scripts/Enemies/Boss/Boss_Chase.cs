using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Chase : Boss_State
{
    private GameObject targetplayer;

    [SerializeField] private float chasespeed;
    [SerializeField] private float chasedist;
    [SerializeField] Boss thisboss;

    public override void OnEnterState(BossController controller)
    {

        base.OnEnterState(controller);
    }
    public override void OnExitState()
    {
        
    }

    public override void OnUpdateState()
    {
        if (targetplayer != null && thisboss != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetplayer.gameObject.transform.position, chasespeed * Time.deltaTime);
            RotateForDestiny();
            if (Vector3.Distance(transform.position, targetplayer.gameObject.transform.position) <= chasedist)
            {

                controller.ChangeState(controller.Attackstate);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D elotro)
    {
        if (elotro.TryGetComponent(out Player player) || (elotro.gameObject.CompareTag("PlayerDetection")))
        {
            Animator animboss = thisboss.GetComponent<Animator>();
            animboss.SetBool("JugadorDetectado", true);
            targetplayer = elotro.gameObject;

        }
    }


    private void OnTriggerExit2D(Collider2D elotro)
    {
        if (elotro.TryGetComponent(out Player player))
        {
            controller.ChangeState(controller.Idlestate);

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
