using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryBar : Bar
{
    private void OnEnable()
    {
        playerStats.hungrySystem.HungryCountChangeEvent += UpdateSliderCount;
    }

    public void UpdateSliderCount(HungrySystem hungrySystem)
    {
        slider.value = hungrySystem.Hungry / hungrySystem.MAXHUNGRYPOINT;
    }

    private void OnDisable()
    {
        playerStats.hungrySystem.HungryCountChangeEvent -= UpdateSliderCount;
    }
}
