using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookForward : MonoBehaviour
{
    private const int LookRayDistance = 3;
    private ISelectableObject lastSelectedObject = null;

    private void FixedUpdate()
    {
        RayCastForward();
    }

    private void RayCastForward()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        Debug.DrawRay(ray.origin, ray.direction * LookRayDistance, Color.red);

        if (Physics.Raycast(ray.origin, ray.direction * 3, out RaycastHit hit))
        {
            var newSelectableObject = hit.collider.gameObject;

            if (newSelectableObject.TryGetComponent(out ISelectableObject selectable)) 
            {
                SelectNewObject(selectable);

                if (Input.GetKeyDown(KeyCode.E))
                    selectable.Interact();
            }
            else
            {
                DiselectItem();
            }
        }
    }

    private void SelectNewObject(ISelectableObject newSelectable)
    {

        if (lastSelectedObject != newSelectable)
        {
            if (lastSelectedObject != null)
            {
                lastSelectedObject?.Disalect();
            }
            lastSelectedObject = newSelectable;

            lastSelectedObject.Select();
            lastSelectedObject.SelectableItemDestroyEvent += DiselectItem;
        }
    }

    private void DiselectItem()
    {
        lastSelectedObject?.Disalect();
        lastSelectedObject = null;
    }
}
