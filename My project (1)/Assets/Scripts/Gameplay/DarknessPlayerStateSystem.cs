using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessPlayerStateSystem : MonoBehaviour
{
    private List<LightEntity> lightEntities = new List<LightEntity>();

    public PlayerStats playerStats;

    private void OnEnable()
    {
        lightEntities.Clear();
        PlayerHitBox.PlayerHitLightEvent += AddToList;
        PlayerHitBox.PlayerQuiteLightEvent += RemoveFromList;
    }

    private void AddToList(LightEntity lightEntity)
    {
        if (lightEntities.Count == 0)
        {
            playerStats.IsOnDarckness = false;
        }
        lightEntities.Add(lightEntity);
    }

    private void RemoveFromList(LightEntity lightEntity)
    {
        lightEntities.Remove(lightEntity);

        if(lightEntities.Count == 0)
        {
            playerStats.IsOnDarckness = true;
        }
    }
    

    private void OnDisable()
    {
        lightEntities.Clear();
        PlayerHitBox.PlayerHitLightEvent -= AddToList;
        PlayerHitBox.PlayerQuiteLightEvent -= RemoveFromList;
    }
}
