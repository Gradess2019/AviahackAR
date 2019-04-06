using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser
{
    public Command ParseToCommand(string commandName, params string[] constructorArgs)
    {
        if (constructorArgs.Length > 0)
        {   
            if (commandName.Equals("TurnLightAction"))
            {
                return new TurnLightAction(constructorArgs);
            } else if (commandName.Equals("HatchAction"))
            {
                return new HatchAction(constructorArgs);
            }
        }   
        
        return null;
    }
}
