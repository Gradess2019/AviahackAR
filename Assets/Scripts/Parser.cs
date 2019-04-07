using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser
{
    public Command ParseToCommand(int operation)
    {
        switch (operation)
        {
            case 1:
            {
                return new TurnLightAction();
            }

            case 2:
            {
                return new HatchAction();
            }

            default:
            {
                return null;
            }
        }
    }
}
