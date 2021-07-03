using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WidgetCanvas : WidgetBase, IPointerDownHandler, IDragHandler
{
    [SerializeField]
    private RawImage canvas;

    public void UpdateValue(RenderTexture texture)
    {
        canvas.texture = texture;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var canvasContext = ContextManager.Instance.GetContext(ContextType.Canvas) as ContextCanvas;
        var brushPickerContext = ContextManager.Instance.GetContext(ContextType.BrushPicker) as ContextBrushPicker;
        var contextColorPicker = ContextManager.Instance.GetContext(ContextType.ColorPicker) as ContextColorPicker;

        // Get local position in image
        Vector2 local;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.rectTransform, eventData.pointerCurrentRaycast.screenPosition, Camera.main, out local);

        local += canvas.rectTransform.rect.size / 2;
        local.y = canvas.texture.height - local.y;

        canvasContext.PaintBrush(contextColorPicker.primaryColor, brushPickerContext.selectedBrush, local);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var canvasContext = ContextManager.Instance.GetContext(ContextType.Canvas) as ContextCanvas;
        var brushPickerContext = ContextManager.Instance.GetContext(ContextType.BrushPicker) as ContextBrushPicker;
        var contextColorPicker = ContextManager.Instance.GetContext(ContextType.ColorPicker) as ContextColorPicker;

        // Get local position in image
        Vector2 local;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.rectTransform, eventData.pointerCurrentRaycast.screenPosition, Camera.main, out local);

        local += canvas.rectTransform.rect.size / 2;
        local.y = canvas.texture.height - local.y;

        canvasContext.PaintBrush(contextColorPicker.primaryColor, brushPickerContext.selectedBrush, local);
    }
}