using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableEnemy : Enemy, IDamageable
{

    public float health;

    public void Damage()
    {
        Debug.Log("Hit " + name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public interface IDestroyable
{
    public void Destroy();
}
