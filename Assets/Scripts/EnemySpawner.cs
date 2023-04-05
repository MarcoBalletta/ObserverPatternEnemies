using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class EnemySpawner : MonoBehaviour
{

    public EnemyMovement enemyPrefab;
    public uint amountOfEnemies;
    public SphereCollider spaceOfSpawning;
    public List<EnemyMovement> listEnemies = new List<EnemyMovement>();

    public delegate void AlertEveryone(PlayerMovement player);
    public AlertEveryone onAlert;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < amountOfEnemies; i++)
        {
            Vector3 randomPosition = Random.insideUnitSphere * spaceOfSpawning.radius + transform.position;
            var enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity, transform);
            enemy.Setup(this);
            listEnemies.Add(enemy);
        }
    }
}
