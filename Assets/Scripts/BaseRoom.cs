using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRoom : BaseComponent , ILightSwitcher
{
    private Light lightComponent;

    protected override void Start()
    {
        base.Start();
        lightComponent = GetComponent<Light>();
        lightComponent.enabled = false;
    }
    public void LightOn()
    {
        lightComponent.color = currentState.GetStateColor();
        lightComponent.enabled = true;
    }

    public void TurnLight()
    {
        lightComponent.enabled = !lightComponent.enabled;
    }
}
