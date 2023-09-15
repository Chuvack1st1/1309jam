
using System;
using UnityEngine;

public interface ISelectableItem 
{

    public void Select();

    public void Disalect();

    public void Interact();

    public event EventHandler SelectableItemDestroyEvent;
}
