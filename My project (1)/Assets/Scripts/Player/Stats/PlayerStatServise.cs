using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatServise : MonoBehaviour
{
    public static PlayerStatServise Instance;

    [SerializeField]
    private PlayerStats playerStats;

    private void Awake()
    {
        if(Instance == null) { Instance = this; }
    }

    public void ApplyHeal(float heal)
    {
        if(heal <= 0)
        {
            throw new System.Exception();
        }
        playerStats.healthSystem.Health += heal;
    }
}
