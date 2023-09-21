using System;
using UnityEngine;

public class Food : MonoBehaviour, IInteractable
{
    public float healthBonus;

    public GameObject SelectedUI;

    public event EventHandler SelectableItemDestroyEvent;

    public void Disalect()
    {
        SelectedUI.SetActive(false);
    }

    public void Interact()
    {
        PlayerStatServise.Instance.ApplyHeal(healthBonus);

        Destroy(gameObject);
        SelectableItemDestroyEvent.Invoke(this, EventArgs.Empty);
    }

    public void Select()
    {
        SelectedUI.SetActive(true);
    }
}
