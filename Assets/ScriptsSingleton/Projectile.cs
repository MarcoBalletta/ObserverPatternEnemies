using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);
        foreach (var enemyD in FindObjectsOfType<HittableEnemy>())
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable enemy))
        {
            Debug.Log("Hit");
            enemy.Damage();
        }
        Destroy(gameObject);
    }

}
