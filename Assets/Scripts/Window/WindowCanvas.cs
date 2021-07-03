using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WindowCanvas : WindowBase
{
    [SerializeField]
    private WidgetCanvas canvas;

    public override void Awake()
    {
        base.Awake();

        UpdateValues();
    }

    protected override void UpdateValues()
    {
        base.UpdateValues();

        var contextCanvas = ContextManager.Instance.GetContext(ContextType.Canvas) as ContextCanvas;

        canvas.UpdateValue(contextCanvas.canvasTexture);
    }
}