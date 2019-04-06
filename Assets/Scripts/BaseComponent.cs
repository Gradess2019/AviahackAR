using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseComponent : MonoBehaviour
{
    [SerializeField]
    protected State currentState;

    void Start()
    {
        currentState = gameObject.AddComponent<NotWorkingState>();
        Debug.Log("PIZDEC");
    }

    void Update()
    {
        
    }

    public void Exec()
    {
        currentState.SetStateMaterial(GetComponent<Renderer>());
    }

}
