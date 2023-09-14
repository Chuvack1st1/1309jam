using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    private void OnEnable()
    {
        playerStats.healthSystem.AntityHealthChangeEvent += UpdateSliderCount;
    }

    public void UpdateSliderCount(HealthSystem healthSystem)
    {
        slider.value = healthSystem.Health / healthSystem.MAXHEALTHPOINT;
    }

    private void OnDisable()
    {
        playerStats.healthSystem.AntityHealthChangeEvent -= UpdateSliderCount;
    }
}
