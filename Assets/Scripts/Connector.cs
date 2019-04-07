using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : BaseRoom, IHatchController
{
    private bool isClosed;
    public void TurnHatch()
    {
        if (isClosed)
        {
            isClosed = false;
            transform.localScale += new Vector3(0.1f, 0, 0);
        } else 
        {
            isClosed = true;
            transform.localScale -= new Vector3(0.1f, 0, 0);
        }
    }
}
