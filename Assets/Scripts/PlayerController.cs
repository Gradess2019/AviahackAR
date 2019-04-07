using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerController : MonoBehaviour
{
    public void DoAction(Command cmd)
    {
        cmd.Execute();
    }

    void Update()
    {
        string[] args = {"1"};
        Command turnLight = new TurnLightAction(args);
        DoAction(turnLight);

        // GameObject obj = null;

        // if (Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     obj = GameObject.Find("Cube");
        // }

        // if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     obj = GameObject.Find("Cube (1)");
        // }

        // if (Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     obj = (GameObject.Find("Cube (2)"));
        // }

        // if (Input.GetKeyDown(KeyCode.Alpha4))
        // {
        //     obj = GameObject.Find("Cube (3)");
        // }

        // if (Input.GetKey(KeyCode.L))
        // {
        //     if (obj)
        //     {
        //         BaseRoom baseObj = obj.GetComponent<BaseRoom>();
        //         if (baseObj)
        //         {
        //             if (baseObj.IsTurnOn())
        //             {
        //                 baseObj.LightOff();
        //             } else 
        //             {
        //                 baseObj.LightOn();                        
        //             }
        //         }
        //     }

        // }
        // else
        // {
        //     if (obj)
        //     {
        //         BaseComponent baseObj = obj.GetComponent<BaseComponent>();
        //         if (baseObj)
        //         {
        //             GetNextState(baseObj);
        //         }
        //     }
        // }

        // BaseComponent[] baseComponents = (FindObjectsOfType<MonoBehaviour>().OfType<BaseComponent>()).ToArray();
        // foreach (BaseComponent currentComponent in baseComponents)
        // {
        //     currentComponent.Exec();
        // }
    }

    private void GetNextState(BaseComponent currentComponent)
    {
        State currentState = currentComponent.GetState();
        if (currentState is WorkingState)
        {
            currentComponent.SetState(currentComponent.gameObject.AddComponent<HasProblemsState>());
        }
        else if (currentState is HasProblemsState)
        {
            currentComponent.SetState(currentComponent.gameObject.AddComponent<NotWorkingState>());
        }
        else
        {
            currentComponent.SetState(currentComponent.gameObject.AddComponent<WorkingState>());
        }

        Destroy(currentState);
    }
}
