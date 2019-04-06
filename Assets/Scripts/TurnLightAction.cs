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
        objectsTags = constructorArgs.Where(arg => arg != constructorArgs[0]).ToArray();
    }

    public override void Execute()
    {
        ILightSwitcher[] objects = null;
        if (objectsTags.Length > 0)
        {
            foreach (string currentTag in objectsTags)
            {
                objects = (GameObject.FindGameObjectsWithTag(currentTag)).Cast<ILightSwitcher>().ToArray();
                SetupLight(objects);
            }
        }
        else
        {
            objects = (FindObjectsOfType<MonoBehaviour>().OfType<ILightSwitcher>()).ToArray();
            SetupLight(objects);
        }
        
    }

    private void SetupLight(ILightSwitcher[] objects)
    {
        foreach (ILightSwitcher currentObject in objects)
        {
            if (turnOn)
            {
                currentObject.LightOn();

            }
            else
            {
                currentObject.LightOff();
            }
        }
    }
}
