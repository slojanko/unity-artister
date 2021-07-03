using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowColorPicker : WindowBase
{
    [SerializeField]
    private WidgetColorSaturationValue colorSaturationValue;
    [SerializeField]
    private WidgetColorHue colorHue;
    [SerializeField]
    private WidgetColorSelected colorSelected;
    [SerializeField]
    private WidgetColorChannel colorChannelRed;
    [SerializeField]
    private WidgetColorChannel colorChannelGreen;
    [SerializeField]
    private WidgetColorChannel colorChannelBlue;
    [SerializeField]
    private WidgetColorChannel colorChannelAlpha;

    public override void Awake()
    {
        base.Awake();

        UpdateValues();
    }

    protected override void UpdateValues()
    {
        base.UpdateValues();

        var contextColorPicker = ContextManager.Instance.GetContext(ContextType.ColorPicker) as ContextColorPicker;

        colorSaturationValue.UpdateValue(contextColorPicker.primaryColor);
        colorHue.UpdateValue(contextColorPicker.primaryColor);
        colorSelected.UpdateValue(contextColorPicker.primaryColor, contextColorPicker.secondaryColor);
        colorChannelRed.UpdateValue(contextColorPicker.primaryColor);
        colorChannelGreen.UpdateValue(contextColorPicker.primaryColor);
        colorChannelBlue.UpdateValue(contextColorPicker.primaryColor);
        colorChannelAlpha.UpdateValue(contextColorPicker.primaryColor);
    }
}
