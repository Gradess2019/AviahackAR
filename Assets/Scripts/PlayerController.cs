using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerController : MonoBehaviour, ICommandReceiver
{
    [SerializeField]
    private Menu menu;
    private TCPServer server;
    void Start()
    {
        server = gameObject.AddComponent<TCPServer>();
        server.SetCommandReceiver(this);
        Invoke("SetupServer", 2);
    }

    private void SetupServer()
    {
        server.StartTCPServer();
        DoAction(1);
        DoAction(3);
        DoAction(1);
        DoAction(3);
        DoAction(1);
        DoAction(3);
        DoAction(1);
        DoAction(3);
    }

    public void DoAction(int operation)
    {
        switch (operation)
        {
            case 1:
                {
                    print(menu.GetSelectedComponent());
                    menu.GoRight();
                    // Debug.Log("go right");
                    
                    break;
                }

            case 2:
                {
                    SwitchLight();
                    Debug.Log("switch light");
                    break;
                }

            case 3:
                {
                    SwitchHatch();
                    Debug.Log("switch hatch");
                    break;
                }

            case 4:
                {
                    Debug.Log("change opacity");
                    //opacity
                    break;
                }

            case 5:
                {
                    menu.GoLeft();
                    Debug.Log("go left");
                    break;
                }
        }
    }

    private void SwitchLight()
    {
        BaseComponent currentComponent = menu.GetSelectedComponent();
        if (currentComponent is ILightSwitcher)
        {
            ILightSwitcher lightSwitcher = currentComponent as ILightSwitcher;
            lightSwitcher.TurnLight();
        }
    }

    private void SwitchHatch()
    {
        BaseComponent currentComponent = menu.GetSelectedComponent();
        if (currentComponent is IHatchController)
        {
            IHatchController lightSwitcher = currentComponent as IHatchController;
            lightSwitcher.TurnHatch();
        }
    }
}
