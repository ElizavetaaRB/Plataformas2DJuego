using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss_State : MonoBehaviour
{
    protected BossController controller;
    public virtual void OnEnterState(BossController controller)
    {
        this.controller = controller;
    }


    public abstract void OnUpdateState();


    public abstract void OnExitState();



}
