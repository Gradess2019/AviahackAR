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
        IHatchController[] objects = null;
        if (objectsTags.Length > 0)
        {
            foreach (string currentTag in objectsTags)
            {
                objects = (GameObject.FindGameObjectsWithTag(currentTag)).Cast<IHatchController>().ToArray();
                SetupHatch(objects);
            }
        }
        else
        {
            objects = (FindObjectsOfType<MonoBehaviour>().OfType<IHatchController>()).ToArray();
            SetupHatch(objects);
        }
    }

    private void SetupHatch(IHatchController[] objects)
    {
        foreach (IHatchController currentObject in objects)
        {
            if (hatchOpen)
            {
                currentObject.HatchOpen();
            }
            else
            {
                currentObject.HatchClose();
            }
        }
    }
}
