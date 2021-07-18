using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WidgetColorSaturationValue : WidgetBase, IPointerDownHandler, IDragHandler
{
    [SerializeField]
    private RectTransform image;
    [SerializeField]
    private RectTransform select;

    public override void Awake()
    {
        base.Awake();

        image.GetComponent<Image>().material = Instantiate(image.GetComponent<Image>().material);
    }

    public void UpdateValue(ColorExt primary)
    {
        image.GetComponent<Image>().material.SetFloat("_Hue", primary.h);
        select.anchoredPosition = new Vector2(primary.s * image.rect.width, (primary.v - 1.0f) * image.rect.height);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SetSelectedColor(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetSelectedColor(eventData);
    }

    public void SetSelectedColor(PointerEventData eventData)
    {
        var context = ContextManager.Instance.GetContext(ContextType.ColorPicker) as ContextColorPicker;

        // Get local position in image
        Vector2 local;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(image, eventData.pointerCurrentRaycast.screenPosition, Camera.main, out local);

        local.y = image.rect.height + local.y;
        local.x = Mathf.Clamp(local.x, 0, image.rect.width);
        local.y = Mathf.Clamp(local.y, 0, image.rect.height);

        // Convert to HSV
        float h, s, v;
        h = context.primaryColor.h;
        s = local.x / image.rect.width;
        v = local.y / image.rect.height;

        context.SetPrimaryColorHSV(h, s, v);
    }
}
