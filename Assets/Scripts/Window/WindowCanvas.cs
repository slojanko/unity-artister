using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WindowCanvas : WindowBase
{
    [SerializeField]
    private WidgetCanvas canvas;

    protected override void UpdateValues()
    {
        base.UpdateValues();

        var contextCanvas = ContextManager.Instance.GetContext(ContextType.Canvas) as ContextCanvas;

        canvas.UpdateValue(contextCanvas.canvasTexture);
    }
}