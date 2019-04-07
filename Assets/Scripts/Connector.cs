using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : BaseRoom, IHatchController
{
    private bool isClosed;

    private Vector3 STEP = new Vector3(0f, 2f, 0f);
    public void TurnHatch()
    {
        if (isClosed)
        {
            isClosed = false;
            transform.localScale += STEP;
        } else 
        {
            isClosed = true;
            transform.localScale -= STEP;
        }
    }
}
