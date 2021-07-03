using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerResize : ContainerComponentBase, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        container.Resize(eventData.delta);
    }
}
