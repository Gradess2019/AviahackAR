using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerController : MonoBehaviour, ICommandReceiver
{
    void Start()
    {
        TCPServer server = gameObject.AddComponent<TCPServer>();
        server.SetCommandReceiver(this);
        server.StartTCPServer();
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

    public void DoAction(int operation)
    {
        switch (operation)
        {
            case 1:
            {

                break;
            }

            case 2:
            {
                
                break;
            }
        }
    }
    
}
