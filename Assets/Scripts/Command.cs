using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Command : MonoBehaviour
{
    protected string[] objectsTags;
    
    public abstract void Execute();

}
