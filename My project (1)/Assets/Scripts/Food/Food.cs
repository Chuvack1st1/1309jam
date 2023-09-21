using System;
using UnityEngine;

public class Food : MonoBehaviour, ISelectableItem, IInteractable
{
    public float healthBonus;

    public GameObject SelectedUI;

    public event Action SelectableItemDestroyEvent;

    public void Disalect()
    {
        SelectedUI.SetActive(false);
    }

    public void Interact()
    {
        PlayerStatServise.Instance.ApplyHeal(healthBonus);

        Destroy(gameObject);
        SelectableItemDestroyEvent.Invoke();
    }

    public void Select()
    {
        SelectedUI.SetActive(true);
    }
}
