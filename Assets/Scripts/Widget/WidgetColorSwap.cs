using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class WidgetColorSwap : WidgetBase, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var context = ContextManager.Instance.GetContext(ContextType.ColorPicker) as ContextColorPicker;

        context.Swap();
    }
}