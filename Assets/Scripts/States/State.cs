using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State
{

    [SerializeField] public string stateName;

    public virtual void OnEnter() { }
    public virtual void OnUpdate() { }
    public virtual void OnExit() { }
}
