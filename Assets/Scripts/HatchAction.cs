using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchAction : Command
{
    private bool hatchOpen;
    public HatchAction(string[] constructorArgs)
    {
        hatchOpen = constructorArgs[0].Equals("1");
        objectTags = constructorArgs.Where(arg => arg != constructorArgs[0]).ToArray();
    }
    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}
