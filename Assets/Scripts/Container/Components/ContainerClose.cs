using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContainerClose : ContainerComponentBase, IPointerClickHandler
{
    [SerializeField]
    private Image image;

    public override void Awake() 
    {
        base.Awake();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        container.Destroy();
    }
}
