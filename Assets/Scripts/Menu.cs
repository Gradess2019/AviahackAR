using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private const int MAXSIZE = 4;

    private int currentIndex;
    public BaseComponent[] rooms;
    public BaseComponent SelectedBaseComponent;

    void Start()
    {
        rooms = FindObjectsOfType<BaseComponent>();

    }

    public void GoLeft()
    {
        if(currentIndex==0)
        SelectedBaseComponent = BaseComponent[MAXSIZE-1];
        else 
        SelectedBaseComponent = BaseComponent[currentIndex--];
    }

    public void GoRight()
    {
        if(currentIndex==MAXSIZE-1)
        SelectedBaseComponent = BaseComponent[0];
        else 
        SelectedBaseComponent = BaseComponent[currentIndex++];
    }

}
