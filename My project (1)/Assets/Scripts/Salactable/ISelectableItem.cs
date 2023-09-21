
using System;
using UnityEngine;

public interface ISelectableItem 
{

    public void Select();

    public void Disalect();

    public event Action SelectableItemDestroyEvent;
}
