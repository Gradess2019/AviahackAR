using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BaseComponent : MonoBehaviour
{
    protected State currentState;

    void Start()
    {
        currentState = gameObject.AddComponent<WorkingState>();
        Invoke("Exec", 0.5f);
    }

    public void Exec()
    {
        currentState.SetStateColor(gameObject);
    }

}
