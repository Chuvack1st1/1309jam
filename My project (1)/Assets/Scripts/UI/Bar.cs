using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField]
    protected PlayerStats playerStats;

    protected Slider slider;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }

}
