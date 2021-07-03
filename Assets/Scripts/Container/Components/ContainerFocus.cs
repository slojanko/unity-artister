using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerFocus : ContainerComponentBase, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        container.Focus();
    }
}