using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public void DoAction(Command cmd)
    {
        cmd.Execute();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BaseComponent[] baseComponents = (FindObjectsOfType<MonoBehaviour>().OfType<BaseComponent>()).ToArray();
            foreach (BaseComponent currentComponent in baseComponents)
            {
                currentComponent.Exec();
            }
        }
    }
}
