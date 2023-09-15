using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyTree : MonoBehaviour
{
    public float startHeal;

    private float health;

    public UnityAction TreeHealthChengeEvent;
    public UnityAction TreeDieEvent;
    public float Health { get => health;
        set 
        {
            health = Mathf.Clamp(value, 0, startHeal);
            TreeHealthChengeEvent?.Invoke();
            if(health == 0)
            {
                TreeDieEvent?.Invoke();
            }
        } 
    }

    private void Start()
    {
        health = startHeal;
    }
}
