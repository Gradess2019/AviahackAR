using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurnLightAction : Command
{
    public override void Execute()
    {
        objects = (FindObjectsOfType<MonoBehaviour>().OfType<ILightSwitcher>()).ToArray();
        
    }
}
