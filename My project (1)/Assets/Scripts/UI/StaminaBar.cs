using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : Bar
{
    private void OnEnable()
    {
        playerStats.staminaSystem.StaminaCountChangeEvent += UpdateSliderCount;
    }

    public void UpdateSliderCount(StaminaSystem staminaSystem)
    {
        slider.value = staminaSystem.Stamina / staminaSystem.MaxStaminaPoint;
    }

    private void OnDisable()
    {
        playerStats.staminaSystem.StaminaCountChangeEvent -= UpdateSliderCount;
    }
}
