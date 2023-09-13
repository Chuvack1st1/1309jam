using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    private bool isOnDarckness;

    public HealthSystem healthSystem = new();

    public bool IsOnDarckness { get => isOnDarckness;
        set 
        { 
            isOnDarckness = value;
            PlayerChangeDarcknessStateEvent.Invoke(this);
        }
    }

    public static UnityAction<PlayerStats> PlayerChangeDarcknessStateEvent;

    private void Start()
    {
        healthSystem.Health = healthSystem.MAXHEALTHPOINT;
    }
}
