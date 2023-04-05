using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public NavMeshAgent agent;
    public float distancePatrol;
    public PlayerMovement playerDetected;
    public float aggroLostDistance;
    public StateManager stateManager;
    public EnemySpawner spawner;
    public bool canAlertEveryone;
    public int percentageAbilityAlert;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateManager = GetComponent<StateManager>();
        canAlertEveryone = Random.Range(0, 100) < percentageAbilityAlert;
        spawner.onAlert += FoundPlayer;
    }

    public void Setup(EnemySpawner sp)
    {
        spawner = sp;
    }

    /*void Patrol()
    {
        //stato di chase - stop patrol

        //raggiunto destinazione - nuova destinazione
        if(agent.destination == null || agent.remainingDistance < agent.stoppingDistance)
        {
            Vector2 offset;
            Vector3 newPosition;
            //cerchiamo nuova destinazione
            do
            {
                offset = Random.insideUnitCircle * distancePatrol;
                newPosition = new Vector3(offset.x, 0, offset.y) + transform.position;
            } while (!agent.SetDestination(newPosition));
        }
        //agent.SetDestination(transform.position);
    }*/

    public void Patrol()
    {
        ClearValues();
        StartCoroutine(Patrolling());
    }

    void ClearValues()
    {
        playerDetected = null;
    }

    private IEnumerator Patrolling()
    {
        while (stateManager.currentState.stateName == "Patrol")
        {
            SetDestination();
            yield return new WaitUntil(() => agent.remainingDistance < agent.stoppingDistance);
        }
    }

    private void SetDestination()
    {
        Vector2 offset;
        Vector3 newPosition;

        offset = Random.insideUnitCircle * distancePatrol;
        newPosition = new Vector3(offset.x, 0, offset.y) + transform.position;
        //NavMesh.SamplePosition(newPosition, out NavMeshHit navmeshHit, distancePatrol, agent.areaMask);
        agent.SetDestination(newPosition);
    }

    #region Chase

    public void Chase()
    {
        StartCoroutine(ChaseCoroutine());
    }

    public void FoundPlayer(PlayerMovement player)
    {
        Debug.Log("Found " + gameObject.name);
        playerDetected = player;
        stateManager.ChangeState("Chase");
    }

    public void TryToAlertEveryone(PlayerMovement player)
    {
        if (canAlertEveryone) spawner.onAlert(player);
    }

    private IEnumerator ChaseCoroutine()
    {
        while(playerDetected != null && agent.remainingDistance < aggroLostDistance && stateManager.currentState.stateName == "Chase")
        {
            agent.destination = playerDetected.transform.position;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Debug.Log("patrol");
        SendMessage("ChangeState", "Patrol");
    }

    #endregion
}
