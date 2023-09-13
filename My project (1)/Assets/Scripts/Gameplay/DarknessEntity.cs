using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessEntity : MonoBehaviour
{
    public float TimeToStartDamage;

    private Coroutine tryDamagePlayerCorutine = null;

    private void OnEnable()
    {
        PlayerStats.PlayerChangeDarcknessStateEvent += HandleNewDarknessPlayerState;
    }

    private void HandleNewDarknessPlayerState(PlayerStats playerStats)
    {
        if (playerStats.IsOnDarckness)
        {
            tryDamagePlayerCorutine = StartCoroutine(TryDamagePlayer(playerStats));
        }
        else
        {
            if(tryDamagePlayerCorutine != null)
                StopCoroutine(tryDamagePlayerCorutine);
            tryDamagePlayerCorutine = null;
        }
    }

    private IEnumerator TryDamagePlayer(PlayerStats playerStats)
    {
        float timeInDarkness = 0;
        while (true)
        {
            if(timeInDarkness < TimeToStartDamage)
            {
                timeInDarkness += Time.deltaTime;
                yield return null;
            }
            else
            {
                playerStats.healthSystem.Health -= playerStats.healthSystem.MAXHEALTHPOINT / 2;
                timeInDarkness = 0;
            }
        }
    }

    private void OnDisable()
    {
        PlayerStats.PlayerChangeDarcknessStateEvent -= HandleNewDarknessPlayerState;
    }
}
