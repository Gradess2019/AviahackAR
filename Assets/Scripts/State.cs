using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField]
    protected Material stateMaterial;

    public void SetStateMaterial(Renderer renderer)
    {
        renderer.material = stateMaterial;
    }
}
