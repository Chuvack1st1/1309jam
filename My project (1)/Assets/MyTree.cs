using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyTree : MonoBehaviour, ISelectableItem
{
    public float startHeal;
    public GameObject SelectedUI;
    private float health;

    public UnityAction TreeHealthChengeEvent;
    public UnityAction TreeDieEvent;

    public event Action SelectableItemDestroyEvent;

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

    public void Disalect()
    {
        SelectedUI.SetActive(false);
    }
    public void Select()
    {
        SelectedUI.SetActive(true);
    }
}
