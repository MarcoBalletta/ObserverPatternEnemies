using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionEnemy : MonoBehaviour
{

    public EnemyMovement enemy;

    private void Start()
    {
        enemy = GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            //enemy.FoundPlayer(player);
            enemy.TryToAlertEveryone(player);
            SendMessageUpwards("ChangeState", "Chase");
        }
    }
}
