using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HatchAction : Command
{
    private bool hatchOpen;
    public HatchAction(string[] constructorArgs)
    {
        hatchOpen = constructorArgs[0].Equals("1");
        objectsTags = constructorArgs.Where(arg => arg != constructorArgs[0]).ToArray();
    }
    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}
