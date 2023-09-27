
using System;
using System.Collections.Generic;

public interface ISelectableObject
{
    
    public void Select();
    public void Interact();

    public void Disalect();

    public event Action SelectableItemDestroyEvent;
}
