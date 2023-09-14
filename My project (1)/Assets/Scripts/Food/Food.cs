using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour, ISelectableItem
{
    public float healthBonus;

    [SerializeField] GameObject SelectedUI;

    public event EventHandler SelectableItemDestroyEvent;

    public void Disalect()
    {
        SelectedUI.SetActive(false);
    }

    public void Interact()
    {
        Debug.Log("food have been eat");

        Destroy(gameObject);
        SelectableItemDestroyEvent.Invoke(this, EventArgs.Empty);
    }

    public void Select()
    {
        SelectedUI.SetActive(true);
    }
}
