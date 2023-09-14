using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class StaminaSystem 
{
    private float stamina;

    public float MaxStaminaPoint;

    public float BusicHealCount;
    public float BusicDeaciseCount;

    public UnityAction<StaminaSystem> StaminaCountChangeEvent;

    public float Stamina
    {
        get => stamina;
        set
        {
            stamina = Mathf.Clamp(value, 0, MaxStaminaPoint);
            StaminaCountChangeEvent?.Invoke(this);
        }
    }
}
