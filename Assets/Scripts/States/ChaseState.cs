using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{

    EnemyMovement enemy;

    public ChaseState(EnemyMovement enemy)
    {
        stateName = "Chase";
        this.enemy = enemy;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        enemy.Chase();
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}
