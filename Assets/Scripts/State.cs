using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected Color stateColor;

    public void SetStateColor(GameObject gameObject)
    {
        gameObject.GetComponent<Renderer>().material.color = stateColor;
    }

    public Color GetStateColor()
    {
        return stateColor;
    }
}
