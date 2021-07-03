using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WidgetColorChannel : WidgetBase, IPointerDownHandler, IDragHandler
{
    [SerializeField]
    private ColorChannel channel;
    [SerializeField]
    private Text text;
    [SerializeField]
    private RectTransform image;
    [SerializeField]
    private RectTransform select;

    public override void Awake()
    {
        base.Awake();

        text.text = channel.ToString()[0].ToString();
    }

    public void UpdateValue(ColorExt primary)
    {
        select.anchoredPosition = new Vector2(primary.GetColorChannel(channel) * image.rect.width, 0.0f);
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

        local.x = Mathf.Clamp(local.x, 0, image.rect.width);

        float value;
        value = local.x / image.rect.width;

        context.SetPrimaryColorChannel(channel, value);
    }
}