using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HealthSystem 
{
    public float MAXHEALTHPOINT;
    private float health;

    public float starvingDamage;
    public float busicHeal;

    public UnityAction<HealthSystem> AntityHealthChangeEvent;

    public UnityAction AntityDieEvent;

    public float Health { get => health; 
        set 
        {
            health = Mathf.Clamp(value, 0, MAXHEALTHPOINT);
            AntityHealthChangeEvent?.Invoke(this);
            if (health == 0)
            {
                AntityDieEvent.Invoke();
            }
        } 
    }
}
