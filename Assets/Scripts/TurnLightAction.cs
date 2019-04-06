using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurnLightAction : Command
{
    private bool turnOn;
    public TurnLightAction(string[] constructorArgs)
    {
        turnOn = constructorArgs[0].Equals("1");
        objectTags = constructorArgs.Where(arg => arg != constructorArgs[0]).ToArray();
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}
