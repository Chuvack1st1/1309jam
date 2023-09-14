using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    private bool isOnDarckness;

    public HealthSystem healthSystem = new();

    public HungrySystem hungrySystem = new();

    public StaminaSystem staminaSystem = new();

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

        hungrySystem.Hungry = hungrySystem.MAXHUNGRYPOINT;

        staminaSystem.Stamina = staminaSystem.MaxStaminaPoint;
    }

    private void FixedUpdate()
    {
        HandleHungrySystem();

        HandleHealthSystem();

        HandleStaminaSystem();
    }

    private void HandleStaminaSystem()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            staminaSystem.Stamina -= staminaSystem.BusicDeaciseCount;
            HandleHungrySystem();
        }
        if(staminaSystem.Stamina != staminaSystem.MaxStaminaPoint)
        {
            staminaSystem.Stamina += staminaSystem.BusicHealCount;
        }
    }

    private void HandleHealthSystem()
    {
        if (hungrySystem.Hungry != 0 && healthSystem.Health != healthSystem.MAXHEALTHPOINT)
        {
            StartHealing();
        }
    }

    private void StartHealing()
    {
        healthSystem.Health += healthSystem.busicHeal;

        HandleHungrySystem();
    }

    private void HandleHungrySystem()
    {
        hungrySystem.Hungry -= hungrySystem.MINHUNGRYDICREASEPOINT;

        if(hungrySystem.Hungry == 0)
        {
            StartStarving();
        }
    }

    private void StartStarving()
    {
        healthSystem.Health -= healthSystem.starvingDamage;
    }
}
