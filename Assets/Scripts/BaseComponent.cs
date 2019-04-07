using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BaseComponent : MonoBehaviour
{
    protected State currentState;

    protected virtual void Start()
    {
        currentState = gameObject.AddComponent<WorkingState>();
        Invoke("Exec", 0.5f);
    }

    public void Exec()
    {
        currentState.SetStateColor(gameObject);
    }

    public void SetState(State newState)
    {
        currentState = newState;
    }

    public State GetState()
    {
        return currentState;
    }

}
