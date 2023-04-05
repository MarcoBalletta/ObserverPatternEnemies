using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;
    public Dictionary<string, State> mapStates = new Dictionary<string, State>();
    public EnemyMovement enemy;

    private void Start()
    {
        enemy = GetComponent<EnemyMovement>();
        SetupDictionary();
        ChangeState("Patrol");
    }

    private void SetupDictionary()
    {
        mapStates.Add("Patrol", new PatrolState(enemy));
        mapStates.Add("Chase", new ChaseState(enemy));
    }

    public void ChangeState(string nextStateKey)
    {
        currentState?.OnExit();
        _ = (mapStates.ContainsKey(nextStateKey)) ? currentState = mapStates[nextStateKey] : null;
        currentState?.OnEnter();
    }

}
