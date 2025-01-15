using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Boss_Idle idlestate;
    private Boss_Attack attackstate;
    private Boss_Chase chasestate;

    private Boss_State currentState;

    public Boss_Idle Idlestate { get => idlestate; }
    public Boss_Attack Attackstate { get => attackstate; }
    public Boss_Chase Chasestate { get => chasestate;}

    // Start is called before the first frame update
    void Start()
    {
        idlestate = GetComponent<Boss_Idle>();
        attackstate = GetComponent<Boss_Attack>();
        chasestate = GetComponent<Boss_Chase>();

       ChangeState(idlestate);
    }

    // Update is called once per frame
    void Update()
    {
        // si tengo estado el cual actualizar
        if (currentState)
        {
            currentState.OnUpdateState();
        }
    }


    public void ChangeState(Boss_State newstate)
    {
        if (currentState) // antes de cambiar mirar si estabamos en estado anterior, hay que cambiar del estado anterior y hacer el nuevo
        {
            currentState.OnExitState();
        }
        currentState = newstate;
        currentState.OnEnterState(this); // este estado tiene que inicializarse
    }
}
