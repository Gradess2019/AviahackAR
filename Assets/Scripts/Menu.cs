using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private const int MAXSIZE = 4;

    private int currentIndex;
    private BaseComponent[] rooms;
    private BaseComponent selectedBaseComponent;

    void Start()
    {
        rooms = FindObjectsOfType<BaseComponent>();
    }

    public void GoLeft()
    {
        if(currentIndex==0)
        {
            selectedBaseComponent = rooms[MAXSIZE-1];
        }
        else 
        {
            selectedBaseComponent = rooms[currentIndex--];
        }
        ShowComponentData();
    }

    private void ShowComponentData()
    {
        //selectedBaseComponent
    }


    public void GoRight()
    {
        if(currentIndex==MAXSIZE-1)
        {
            selectedBaseComponent = rooms[0];
        }
        else 
        {
            selectedBaseComponent = rooms[currentIndex++];
        }
        ShowComponentData();
    }

    public BaseComponent GetSelectedComponent()
    {
        return selectedBaseComponent;
    }

}
