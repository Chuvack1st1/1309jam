using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class HungrySystem 
{
    private float hungry;

    public float MAXHUNGRYPOINT;

    public float MINHUNGRYDICREASEPOINT;

    public UnityAction<HungrySystem> HungryCountChangeEvent;

    public float Hungry { get => hungry;
    set 
        {  
            hungry = Mathf.Clamp(value, 0, MAXHUNGRYPOINT);
            HungryCountChangeEvent?.Invoke(this);
        }
    }
}
