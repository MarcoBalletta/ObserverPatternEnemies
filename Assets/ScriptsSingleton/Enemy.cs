using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Enemy : MonoBehaviour
{
    public string nameEnemy;
}

public interface IDamageable
{
    public void Damage();
}
