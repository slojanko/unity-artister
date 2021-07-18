using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WidgetColorHue : WidgetBase, IPointerDownHandler, IDragHandler
{
    [SerializeField]
    private RectTransform image;
    [SerializeField]
    private RectTransform select;

    public void UpdateValue(ColorExt primary)
    {
        select.anchoredPosition = new Vector2(0.0f, -primary.h * image.rect.height);
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
        local.y = Mathf.Clamp(local.y, 0, image.rect.height);

        // Convert to HSV
        float h, s, v;
        h = 1.0f - local.y / image.rect.height;
        s = context.primaryColor.s;
        v = context.primaryColor.v;

        context.SetPrimaryColorHSV(h, s, v);
    }
}
