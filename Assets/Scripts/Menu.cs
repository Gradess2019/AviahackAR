using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private const int MAXSIZE = 4;

    private int currentIndex;
    private BaseComponent[] rooms;
    private BaseComponent selectedBaseComponent;

    [SerializeField]
    private Text lightText;

    [SerializeField]
    private Text hatchText;

    void Start()
    {
        currentIndex = 0;
        rooms = FindObjectsOfType<BaseComponent>();
        if (rooms.Length > 0)
        {
            selectedBaseComponent = rooms[0];
        }
    }

    public void GoLeft()
    {
        if (currentIndex == 0)
        {
            selectedBaseComponent = rooms[MAXSIZE - 1];
            currentIndex = MAXSIZE - 1;
        }
        else
        {
            selectedBaseComponent = rooms[currentIndex--];
        }
        ShowComponentData();
    }

    private void ShowComponentData()
    {
        if (selectedBaseComponent is ILightSwitcher)
        {
            lightText.gameObject.SetActive(true);
        }
        else
        {
            lightText.gameObject.SetActive(false);
        }

        if (selectedBaseComponent is IHatchController)
        {
            hatchText.gameObject.SetActive(true);
        }
        else
        {
            hatchText.gameObject.SetActive(false);
        }
    }


    public void GoRight()
    {
        if (currentIndex == MAXSIZE - 1)
        {
            selectedBaseComponent = rooms[0];
            currentIndex = 0;
        }
        else
        {
            selectedBaseComponent = rooms[++currentIndex];

        }
        ShowComponentData();
    }

    public BaseComponent GetSelectedComponent()
    {
        return selectedBaseComponent;
    }

}
