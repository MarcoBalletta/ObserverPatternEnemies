using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{

    public EnemyMovement enemy;

    public PatrolState(EnemyMovement enemy)
    {
        stateName = "Patrol";
        this.enemy = enemy;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        enemy.Patrol();
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
