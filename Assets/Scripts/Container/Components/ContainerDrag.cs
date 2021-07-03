using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerDrag : ContainerComponentBase, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        container.Drag(eventData.delta);
    }
}
