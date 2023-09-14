using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private ISelectableItem lastSelectedObject = null;

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        // Draw the ray in the scene view
        Debug.DrawRay(ray.origin, ray.direction * 3, Color.red);

        if (Physics.Raycast(ray.origin, ray.direction * 3, out RaycastHit hit))
        {
            var Selectable = hit.collider.gameObject.GetComponentInParent<ISelectableItem>();
            if (Selectable != null)
            {
                if(lastSelectedObject != Selectable)
                {
                    lastSelectedObject?.Disalect();

                    lastSelectedObject = Selectable;
                    lastSelectedObject.SelectableItemDestroyEvent += DiselectItem;
                    lastSelectedObject.Select();
                }

                if(Input.GetKeyDown(KeyCode.E))
                    lastSelectedObject.Interact();

            }
            else
            {
                DiselectItem(this, EventArgs.Empty);
            }
        }
    }

    private void DiselectItem(object sender, EventArgs e)
    {
        lastSelectedObject?.Disalect();
        lastSelectedObject = null;
    }
}
