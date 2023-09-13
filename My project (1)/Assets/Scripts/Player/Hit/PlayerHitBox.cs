using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PlayerHitBox : MonoBehaviour
{
    public static UnityAction<LightEntity> PlayerHitLightEvent;
    public static UnityAction<LightEntity> PlayerQuiteLightEvent;

    private void OnTriggerEnter(Collider other)
    {
        var lightEntity = other.gameObject.GetComponent<LightEntity>();
        if(lightEntity != null)
        {
            PlayerHitLightEvent?.Invoke(lightEntity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var lightEntity = other.gameObject.GetComponent<LightEntity>();
        if (lightEntity != null)
        {
            PlayerQuiteLightEvent?.Invoke(lightEntity);
        }
    }
}
